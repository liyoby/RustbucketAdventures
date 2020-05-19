using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMagnetism : MonoBehaviour
{
    public GameObject magPoint;
    public DistanceJoint2D joint;
    public LayerMask magnetLayerMask;
    public Rigidbody2D magPointRb;
    public LineRenderer lineRend;
    public static bool isColliding;
    private float liftSpeed;
    private bool distanceSet;
    private float maxMagDistance;
    private bool isAttached;
    private Vector2 playerPosition;
    private List<Vector2> linePoints = new List<Vector2>(); 

    public float maxMagnetCharge;
    public float currentMagnetCharge;
    public float lostCharge;
    public GameObject crossHairs;
    public SpriteRenderer spriteRend;
    public PlayerController playerController;

    public GameObject electroBall;          //projectile
    public Transform magnetTip;             //where electroball spawns
    private float timerBtwShots;             //timer for shots
    public float shotTime;                  //timer's reset value

    // Start is called before the first frame update
    void Start()
    {
        liftSpeed = 20f;
        joint.enabled = false;
        maxMagDistance = 30f;
        playerPosition = transform.position;
        maxMagnetCharge = 100;
        currentMagnetCharge = maxMagnetCharge;
        spriteRend.enabled = false;
        lostCharge = 25;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float zRotation = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
        var aimDirection = transform.rotation;

        if (Input.GetButtonDown("Electricity") && timerBtwShots <= 0)
        {
            playerController.AnimateAim();
            ShootElectricity();
            timerBtwShots = shotTime;
            playerController.AnimateShoot();
        }
        else
        {
            timerBtwShots -= Time.deltaTime;
        }

        playerPosition = transform.position;
        if (Input.GetButton("Magnetism") && currentMagnetCharge >= 25)
        {
            //Debug.Log("Down");
            //show crosshairs 
            spriteRend.enabled = true;
            //playerController.AnimateAim();
           
        }


        //check button release
        if (Input.GetButtonUp("Magnetism") && currentMagnetCharge >= 25)
        {
            //Debug.Log("Up");
            spriteRend.enabled = false;
            //playerController.AnimateShoot();

            var hit = Physics2D.Raycast(playerPosition, aimDirection * Vector2.right, maxMagDistance, magnetLayerMask);

            if (hit.collider != null)
            {
                isAttached = true;

                if (!linePoints.Contains(hit.point))
                {
                    playerController.BounceUp();
                    linePoints.Add(hit.point);
                    joint.distance = Vector2.Distance(playerPosition, hit.point);
                    joint.enabled = true;
                    ReduceCharge();
                }
            }

            else
            {
                isAttached = false;
                joint.enabled = false;
                lineRend.SetPosition(0, transform.position);
                lineRend.SetPosition(1, transform.position);
                linePoints.Clear();
            }
        }

        LiftOff();
        UpdatePositions();
    }

    public void LiftOff()
    {
        if(!isAttached)
        {
            return;
        }
        else if(isAttached && !isColliding)
        { 
            joint.distance -= Time.deltaTime * liftSpeed;
        } 
    }
    private void UpdatePositions()
    {
        if(!isAttached)
        {
            return;
        }

        lineRend.positionCount = linePoints.Count + 1;

        for(var i = lineRend.positionCount - 1; i >= 0; i--)
        {
            if(i != lineRend.positionCount - 1)
            {
                lineRend.SetPosition(i, linePoints[i]);

                if(i == linePoints.Count - 1 || linePoints.Count == 1)
                {
                    var linePoint = linePoints[linePoints.Count - 1];

                    if(linePoints.Count == 1)
                    {
                        magPointRb.transform.position = linePoint;
                        if(!distanceSet)
                        {
                            joint.distance = Vector2.Distance(transform.position, linePoint);

                            distanceSet = true;
                        }
                    }

                    else
                    {
                        magPointRb.transform.position = linePoint;
                        if (!distanceSet)
                        {
                            joint.distance = Vector2.Distance(transform.position, linePoint);

                            distanceSet = true;
                        }
                    }
                }

                else if(i - 1 == linePoints.IndexOf(linePoints.Last()))
                {
                    var linePoint = linePoints.Last();
                    magPointRb.transform.position = linePoint;
                    if(!distanceSet)
                    {
                        joint.distance = Vector2.Distance(transform.position, linePoint);
                        distanceSet = true;
                    }
                }
            }
            else
            {
                lineRend.SetPosition(i, transform.position);
            }
        }
    }

    public void ShootElectricity()
    {
        Instantiate(electroBall, magnetTip.position, magnetTip.rotation);
    }

    public void RefillCharge()
    {
        currentMagnetCharge = maxMagnetCharge;
    }

    public void ReduceCharge()
    {
        currentMagnetCharge -= lostCharge;
    }
}

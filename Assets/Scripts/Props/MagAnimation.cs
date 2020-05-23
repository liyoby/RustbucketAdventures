using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagAnimation : MonoBehaviour
{
    public Animator magAnimator;
    // Start is called before the first frame update
    void Start()
    {
        magAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WasTouched()
    {
        magAnimator.SetTrigger("PowerUp");
    }
}

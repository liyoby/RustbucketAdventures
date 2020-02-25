using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EndCredits : MonoBehaviour
{
    public Canvas endCanvas;
    public float splashTimer;

    // Start is called before the first frame update
    void Start()
    {
        endCanvas = GetComponent<Canvas>();
        splashTimer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        splashTimer -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            NextButtonPressed();
        }

        else if (splashTimer <= 0)
        {
            //after refinement period will call StartEndCredits instead
            NextButtonPressed();
        }
    }

    //skips to main menu scene
    public void NextButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartEndCredits()
    {
        //start mp4 video
    }

}


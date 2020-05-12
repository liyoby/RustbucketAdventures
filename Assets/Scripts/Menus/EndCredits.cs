using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class EndCredits : MonoBehaviour
{
    public Canvas endCanvas;
    public float splashTimer;
    public VideoPlayer videoPlayer;
    double videoLength;
    double currentLength;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject camera = GameObject.Find("Main Camera");
        splashTimer = 3.5f;
        videoLength = gameObject.GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        currentLength = gameObject.GetComponent<VideoPlayer>().time;
        splashTimer -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            NextButtonPressed();
        }

        else if (splashTimer <= 0)
        {
            StartEndCredits();
            endCanvas.enabled = false;
            
        }

        if (currentLength >= videoLength)
        {
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
        videoPlayer.Play();
        
    }

}


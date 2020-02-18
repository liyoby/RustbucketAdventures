using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{
    public Canvas pauseCanvas;
    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();  
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        pauseCanvas.enabled = true;
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseCanvas.enabled = false;
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void QuitButtonPressed()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
		        Application.Quit();
        #endif
    }
}

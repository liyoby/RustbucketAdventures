using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenu : MonoBehaviour
{
    public Canvas titleCanvas;

    // Start is called before the first frame update
    void Start()
    {
        titleCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonPressed()
    {
        SceneManager.LoadScene("Level1");
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

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
    public InstructionMenu IMenu;
    public StoryMenu StoryMenu;

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
        SceneManager.LoadScene("ProtoType");
    }

    public void InstructionButtonPressed()
    {
        IMenu.instructionCanvas.enabled = true;
        titleCanvas.enabled = false;
    }

    public void StoryButtonPressed()
    {
        StoryMenu.storyCanvas.enabled = true;
        titleCanvas.enabled = false;
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

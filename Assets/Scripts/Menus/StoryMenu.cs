using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenu : MonoBehaviour
{
    public Canvas storyCanvas;
    public StartMenu StartMenu;

    // Start is called before the first frame update
    void Start()
    {
        storyCanvas = GetComponent<Canvas>();
    }

    public void SBackButtonPressed()
    {
        StartMenu.titleCanvas.enabled = true;
        storyCanvas.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionMenu : MonoBehaviour
{
    public Canvas instructionCanvas;
    public StartMenu StartMenu;

    // Start is called before the first frame update
    void Start()
    {
        instructionCanvas = GetComponent<Canvas>();
    }

    public void IBackButtonPressed()
    {
        StartMenu.titleCanvas.enabled = true;
        instructionCanvas.enabled = false;
    }
}

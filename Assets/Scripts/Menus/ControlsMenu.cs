using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public Canvas controlsCanvas;
    public PauseManager PauseM;

    // Start is called before the first frame update
    void Start()
    {
        controlsCanvas = GetComponent<Canvas>();
    }

    public void CBackButtonPressed()
    {
        PauseM.pauseCanvas.enabled = true;
        controlsCanvas.enabled = false;
    }
}

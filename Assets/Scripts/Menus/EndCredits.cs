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

    // Start is called before the first frame update
    void Start()
    {
        endCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartButtonPressed()
    {
        SceneManager.LoadScene("Level1");
    }

}


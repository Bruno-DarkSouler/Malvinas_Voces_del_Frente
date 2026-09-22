using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreenController : MonoBehaviour
{
    public GameObject introScreen;
    public bool screenActive = true;

    public TimeManager timeManager;

    public ArduinoController arduinoController;

    void Start()
    {
        arduinoController.Button6Pressed += StartGame;
    }

    
    void Update()
    {
        if(screenActive && Input.GetKeyDown(KeyCode.E))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        if (!screenActive) return;

        screenActive = false;
        introScreen.SetActive(false);

        if(timeManager != null)
        {
            timeManager.timeIsRunning = true;
        }
    }
}

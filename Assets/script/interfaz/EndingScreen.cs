using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScreen : MonoBehaviour
{
    public GameObject victoryScreen;
    public TimeManager timeManager;
    private bool playerInside = false;
    private bool alreadyWon = false;
    public int minuteOfWinning = 190;

    public ArduinoController arduinoController;

    void Start()
    {
        victoryScreen.SetActive(false);

        arduinoController.Button6Pressed += ReloadGame;
        arduinoController.Button7Pressed += QuitGame;
    }

    void Update()
    {
        if (alreadyWon)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();

                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }

            return;
        }


        if (!playerInside) return;

        if (timeManager.timePassed / 60 > minuteOfWinning) //instead of 60 it should be timeManager.timeMultiplier
        {
            alreadyWon = true;
            victoryScreen.SetActive(true);
        }

    }

    public void ReloadGame()
    {
        if (alreadyWon)
        {
            UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    public void QuitGame()
    {
        if (alreadyWon)
        {
            Application.Quit();

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOver;
    public TextMeshProUGUI gameOverText;
    public Button reset;
    public Button menu;

    private bool gameOverActive;

    public ArduinoController arduinoController;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        if (gameOver != null)
        {
            gameOver.SetActive(false);
        }
        /*if (reset != null)
        {
            reset.onClick.AddListener(ResetScene);
        }
        if (menu != null)
        {
            menu.onClick.AddListener(Menu);
        }*/

        arduinoController.Button6Pressed += ReloadGame;
        arduinoController.Button7Pressed += QuitGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ResetScene();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame();
            }
        }
    }

    public void GameOver()
    {
        if (gameOverActive) return;
        gameOverActive = true;

        if (gameOver != null)
        {
            gameOver.SetActive(true);
        }


    }

    public void ResetScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }



    public void ReloadGame()
    {
        if (gameOverActive)
        {
            UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    public void QuitGame()
    {
        if (gameOverActive)
        {
            Application.Quit();

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}

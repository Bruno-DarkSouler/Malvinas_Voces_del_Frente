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


    //CAmbios que no importan

    



    // Start is called before the first frame update
    void Start()
    {
        if (gameOver != null)
        {
            gameOver.SetActive(false);
        }
        if (reset != null)
        {
            reset.onClick.AddListener(ResetScene);
        }
        if (menu != null)
        {
            menu.onClick.AddListener(Menu);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverActive)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetScene();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Menu();
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

        if (gameOverText != null)
        {
            gameOverText.text = "You Dead\n\nR - Reiniciar\nEsc - Volver al Menu";
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void LoadLevel(string levelName)
    {
        Debug.Log("Cargando nivel: " + levelName);
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }

    public void PauseGame()
    {
        Debug.Log("Pausando el juego");
        Time.timeScale = 0;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Debug.Log("Reanudando el juego");
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

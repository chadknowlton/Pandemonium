using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlPage;

    void Start()
    {
        pauseMenu.SetActive(false);
        controlPage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.isPausedStats)
        {
            if (GameManager.isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameManager.isPaused = true;
        pauseMenu.SetActive(true);

        if (controlPage.activeSelf)
        {
            controlPage.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        GameManager.isPaused = false;
        pauseMenu.SetActive(false);

        if (controlPage.activeSelf)
        {
            controlPage.SetActive(false);
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        GameManager.isPaused = false;
    }

    public void BackButton()
    {
        controlPage.SetActive(false);
    }

    public void OpenControlsPage()
    {
        controlPage.SetActive(true);
    }
}

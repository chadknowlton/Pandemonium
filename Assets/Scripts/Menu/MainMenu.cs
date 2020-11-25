using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;

    private GameObject controlPage;
    private GameObject loadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        controlPage = menu.transform.Find("ControlPage").gameObject;
        controlPage.SetActive(false);
        loadingScreen = menu.transform.Find("LoadingScreen").gameObject;
        loadingScreen.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(controlPage.activeSelf)
            {
                BackButton();
            }
        }
    }

    public void NewGame()
    {
        PlayerData.NewGame();
        TowerData.NewGame();
        GameObject.Find("GameManager").GetComponent<LevelLoader>().LoadLevel("Tyche_System");
    }

    public void ControlButton()
    {
        controlPage.SetActive(true);
    }

    public void BackButton()
    {
        controlPage.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

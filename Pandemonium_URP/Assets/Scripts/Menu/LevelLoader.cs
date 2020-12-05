using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;
    public TMP_Text loadingText;

    private void Start()
    {
        loadingScreen.SetActive(false);
    }

    public void LoadLevel(string levelName)
    {
        if (levelName == "Test_Player_")
        { 
            if(TowerData.CurrentFloor % 2 == 0)
            {
                levelName += "2";
            }
            else
            {
                levelName += "1";
            }
        }

        StartCoroutine(LoadLevelAsync(levelName));
    }

    private IEnumerator LoadLevelAsync(string levelName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelName);

        loadingScreen.SetActive(true);

        while(!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            loadingBar.value = progress;
            loadingText.text = (progress * 100) + "%";
            yield return null;
        }
    }
}

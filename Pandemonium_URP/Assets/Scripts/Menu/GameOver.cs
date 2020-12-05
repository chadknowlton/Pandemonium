using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPage;
    public TMP_Text gameOverLabel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GameIsOver()
    {
        yield return null;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameOverPage.SetActive(true);

        int highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        int score = PlayerData.Highscore;

        if(score > highscore)
        {
            gameOverLabel.text = "GAME OVER\nNew Highscore\nYourScore: " + score;
            PlayerPrefs.SetInt("HIGHSCORE", score);
        }
        else
        {
            gameOverLabel.text = "GAME OVER\nYourScore: " + score;
        }
    }
}

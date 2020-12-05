using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScript : MonoBehaviour
{
    public GameObject winPage;
    public TMP_Text winText;

    private string normalLabel = "Pandemonium is over!\n\n"
        + "Your Score: ";

    private string highscoreLabel = "Pandemonium is over!\n\n"
    + "New Highscore!\n"
    + "Your Score: ";


    // Start is called before the first frame update
    void Start()
    {
        winPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WinGame()
    {
        yield return new WaitForSeconds(1f);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        winPage.SetActive(true);

        GameManager.isPaused = true;
        GameManager.isPausedStats = true;

        int highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        int score = PlayerData.Highscore;

        if (score > highscore)
        {
            winText.text = highscoreLabel + score;
            PlayerPrefs.SetInt("HIGHSCORE", score);
        }
        else
        {
            winText.text = normalLabel + score;
        }
    }
}

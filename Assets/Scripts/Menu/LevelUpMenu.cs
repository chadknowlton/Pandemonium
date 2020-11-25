using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject statPage;
    public GameObject player;

    public TMP_Text scoreText;
    public TMP_Text levelText;
    public TMP_Text skillpointleftText;
    public TMP_Text intelligenceText;
    public TMP_Text defenseText;
    public TMP_Text constitutionText;
    public TMP_Text dexterityText;

    public Button[] decreaseButtons;
    public Button[] increaseButtons;
    public Button finishButton;


    private int[] stats;
    // 0 = Score
    // 1 = Level
    // 2 = Skill Points Left
    // 3 = Intelligence
    // 4 = Defense
    // 5 = Constitution
    // 6 = Dexterity

    private int[] statsCounter = { 0, 0, 0, 0, 0};

    void Start()
    {
        statPage.SetActive(false);
    }

    void Update()
    {
        
    }

    public void startLevelUp()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameManager.isPaused = true;
        GameManager.isPausedStats = true;
        Time.timeScale = 0f;

        statPage.SetActive(true);

        stats = PlayerData.GetForStatsScreen();
       
        for(int i = 0; i < 5; i++)
        {
            statsCounter[i] = stats[i + 2];
            Debug.Log(statsCounter[i]);
        }

        scoreText.text = "SCORE: " + stats[0];
        levelText.text = "Level: " + stats[1];
        skillpointleftText.text = "" + stats[2];
        intelligenceText.text = "" + stats[3];
        defenseText.text = "" + stats[4];
        constitutionText.text = "" + stats[5];
        dexterityText.text = "" + stats[6];

        foreach (Button button in decreaseButtons)
        {
            button.interactable = false;
        }

        if (stats[2] < 1)
        {
            foreach (Button button in increaseButtons)
            {
                button.interactable = false;
            }
        }
        else
        {
            finishButton.interactable = false;
        }
    }

    public void IncreaseButton(int index)
    {
        stats[2]--;
        skillpointleftText.text = "" + stats[2];

        if (index == 1)
        {
            stats[3]++;
            intelligenceText.text = "" + stats[3];
            decreaseButtons[0].interactable = true;
        }
        else if (index == 2)
        {
            stats[4]++;
            defenseText.text = "" + stats[4];
            decreaseButtons[1].interactable = true;
        }
        else if (index == 3)
        {
            stats[5]++;
            constitutionText.text = "" + stats[5];
            decreaseButtons[2].interactable = true;
        }
        else if (index == 4)
        {
            stats[6]++;
            dexterityText.text = "" + stats[6];
            decreaseButtons[3].interactable = true;
        }

        if(stats[2] < 1)
        {
            foreach(Button button in increaseButtons)
            {
                button.interactable = false;
            }

            finishButton.interactable = true;
        }
    }

    public void DecreaseButton(int index)
    {
        if(stats[2] == 0)
        {
            foreach (Button button in increaseButtons)
            {
                button.interactable = true;
            }

            finishButton.interactable = false;
        }

        stats[2]++;
        skillpointleftText.text = "" + stats[2];

        if (index == 1)
        {
            stats[3]--;
            intelligenceText.text = "" + stats[3];

            if (stats[3] == statsCounter[1])
            {
                decreaseButtons[0].interactable = false;
            }
        }
        else if (index == 2)
        {
            stats[4]--;
            defenseText.text = "" + stats[4];

            if (stats[4] == statsCounter[2])
            {
                decreaseButtons[1].interactable = false;
            }
        }
        else if (index == 3)
        {
            stats[5]--;
            constitutionText.text = "" + stats[5];

            if (stats[5] == statsCounter[3])
            {
                decreaseButtons[2].interactable = false;
            }
        }
        else if (index == 4)
        {
            stats[6]--;
            dexterityText.text = "" + stats[6];

            if (stats[6] == statsCounter[4])
            {
                decreaseButtons[3].interactable = false;
            }
        }
    }

    public void FinishedButton()
    {
        PlayerData.SetFrorStatsScreen(stats);
        player.GetComponent<PlayerStatus>().UpdatePlayerStatus();
        player.GetComponent<ThirdPersonMovement>().UpdateMovement();
        player.GetComponent<Shooting>().UpdateShooting();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameManager.isPaused = false;
        GameManager.isPausedStats = false;
        Time.timeScale = 1f;

        statPage.SetActive(false) ;
    }

}

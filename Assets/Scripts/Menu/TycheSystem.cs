using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TycheSystem : MonoBehaviour
{
    public GameObject rankMenu;
    public GameObject numberMenu;

    public Button aRankButton;
    public Button bRankButton;
    public Button cRankButton;
    public Button dRankButton;

    private TMP_Text description;
    private TMP_Text numberLabel;
    private Slider multiplierSlider;
    private TMP_Text multiplierText;
    private Button readyButton;

    private float aRankMult = 0f;
    private float bRankMult = 0f;
    private float cRankMult = 0f;
    private float dRankMult = 0f;

    private float aRankSliderValue = 0f;
    private float bRankSliderValue = 0f;
    private float cRankSliderValue = 0f;
    private float dRankSliderValue = 0f;

    private bool isRankChosen;
    private char chosenRank = ' ';
    private float multiplier = 1f;
    private int numberToSpawn = 0;

    private int spawnLimit;
    private int minSpawn;
    private float multiplierIncrement;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        rankMenu.SetActive(false);
        numberMenu.SetActive(false);

        minSpawn = TowerData.GetMin();
        spawnLimit = TowerData.GetMax();
    }

    void Update()
    {
    }

    public void RankButton()
    {
        int count = 4;
        float multiplierIncrement;

        isRankChosen = true;
        rankMenu.SetActive(true);

        description = rankMenu.transform.Find("Description").GetComponent<TMP_Text>();
        multiplierSlider = rankMenu.transform.Find("ExpMultiplierSlider").GetComponent<Slider>();
        multiplierText = rankMenu.transform.Find("ExpMultiplierText").GetComponent<TMP_Text>();
        readyButton = rankMenu.transform.Find("ReadyButton").GetComponent<Button>();

        multiplierSlider.gameObject.SetActive(false);
        multiplierText.gameObject.SetActive(false);
        readyButton.interactable = false;


        if (TowerData.GetRemainingMonsterleft('D') < 1)
        {
            dRankButton.interactable = false;
            count--;
        }

        if (TowerData.GetRemainingMonsterleft('C') < 1)
        {
            cRankButton.interactable = false;
            count--;
        }

        if (TowerData.GetRemainingMonsterleft('B') < 1)
        {
            bRankButton.interactable = false;
            count--;
        }

        if (TowerData.GetRemainingMonsterleft('A') < 1)
        {
            aRankButton.interactable = false;
            count--;
        }

        multiplierSlider.maxValue = count;

        if (count < 2)
        {
            multiplierIncrement = 0f;
        }
        else
        {
            multiplierIncrement = 1f / (count - 1);
            multiplierIncrement = Mathf.Round(multiplierIncrement * 100f) / 100f;
        }

        GetMultiplierRank(multiplierIncrement);
    }

    private void GetMultiplierRank(float value)
    {
        float increment = value;
        int count = 0;

        if (TowerData.GetRemainingMonsterleft('D') > 0)
        {
            dRankMult = 1 + (increment * count);
            count++;
            dRankSliderValue = count;
        }

        if (TowerData.GetRemainingMonsterleft('C') > 0)
        {
            cRankMult = 1 + (increment * count);
            count++;
            cRankSliderValue = count;
        }

        if (TowerData.GetRemainingMonsterleft('B') > 0)
        {
            bRankMult = 1 + (increment * count);
            count++;
            bRankSliderValue = count;
        }

        if (TowerData.GetRemainingMonsterleft('A') > 0)
        {
            aRankMult = 1 + (increment * count);
            aRankMult = Mathf.Round(aRankMult);
            count++;
            aRankSliderValue = count;
        }
    }

    public void PickARank(string rank)
    {
        if (!multiplierSlider.gameObject.activeSelf)
        {
            multiplierSlider.gameObject.SetActive(true);
            multiplierText.gameObject.SetActive(true);
        }

        if (!readyButton.interactable)
        {
            readyButton.interactable = true;
        }

        description.text = "You chose " + rank + " Rank.";
        chosenRank = rank[0];

        if (chosenRank == 'D')
        {
            multiplier = 1f;
            multiplierSlider.value = dRankSliderValue;
            multiplierText.text = "Multiplier: " + dRankMult + "x Experience";
        }
        else if (chosenRank == 'C')
        {
            multiplier = cRankMult;
            multiplierSlider.value = cRankSliderValue;
            multiplierText.text = "Multiplier: " + cRankMult + "x Experience";
        }
        else if (chosenRank == 'B')
        {
            multiplier = bRankMult;
            multiplierSlider.value = bRankSliderValue;
            multiplierText.text = "Multiplier: " + bRankMult + "x Experience";
        }
        else if (chosenRank == 'A')
        {
            multiplier = aRankMult;
            multiplierSlider.value = aRankSliderValue;
            multiplierText.text = "Multiplier: " + aRankMult + "x Experience";
        }
    }

    public void NumberButton()
    {
        TowerData.isRank = false;
        numberMenu.SetActive(true);

        description = numberMenu.transform.Find("Description").GetComponent<TMP_Text>();
        numberLabel = numberMenu.transform.Find("NumberLabel").Find("Number").GetComponent<TMP_Text>();
        multiplierSlider = numberMenu.transform.Find("ExpMultiplierSlider").GetComponent<Slider>();
        multiplierText = numberMenu.transform.Find("ExpMultiplierText").GetComponent<TMP_Text>();
        readyButton = numberMenu.transform.Find("ReadyButton").GetComponent<Button>();

        numberToSpawn = minSpawn;

        multiplierSlider.minValue = minSpawn - 1;
        multiplierSlider.value = minSpawn;
        multiplierSlider.maxValue = spawnLimit;
        numberLabel.text = "" + numberToSpawn;
        multiplierText.text = "Multiplier: " + multiplier + "x Experience";

        GetMultiplierNumber();
    }

    public void DecreaseNumber()
    {
        if (numberToSpawn > minSpawn)
        {
            numberToSpawn--;
            multiplierSlider.value = numberToSpawn;
            numberLabel.text = "" + numberToSpawn;
            multiplier -= multiplierIncrement;
            multiplierText.text = "Multiplier: " +
                Mathf.Round(multiplier * 100f) / 100f + "x Experience";
        }
    }

    public void IncreaseNumber()
    {
        if (numberToSpawn < spawnLimit)
        {
            numberToSpawn++;
            multiplierSlider.value = numberToSpawn;
            numberLabel.text = "" + numberToSpawn;
            multiplier += multiplierIncrement;
            multiplierText.text = "Multiplier: " +
                Mathf.Round(multiplier * 100f) / 100f + "x Experience";
        }
    }

    public void ReadyButton()
    {
        TowerData.isRank = isRankChosen;
        TowerData.rank = chosenRank;
        TowerData.multiplier = Mathf.Round(multiplier * 100f) / 100f;
        TowerData.ToSpawn = numberToSpawn;
    }

    private void GetMultiplierNumber()
    {
        multiplierIncrement  = 1f / (spawnLimit - minSpawn);
    }
}
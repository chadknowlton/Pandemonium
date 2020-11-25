using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    public Slider healthSlider;
    public Slider expSlider;
    public TMP_Text healthText;
    public TMP_Text expText;
    public TMP_Text levelText;
    public TMP_Text scoreText;


    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    [SerializeField] private int maxEXP;
    [SerializeField] private int currentEXP;
    [SerializeField] private float expMultiplier;
    [SerializeField] private int score;

    private float EndofLevelHeal = 0.5f;

    public static bool isDead = false;

    void Start()
    {
        maxHealth = PlayerData.GetMaxHealth();
        currentHealth = PlayerData.CurrentHealth;
        maxEXP = PlayerData.GetMaxEXP();
        currentEXP = PlayerData.CurrentEXP;
        expMultiplier = TowerData.multiplier;
        score = PlayerData.Highscore;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        expSlider.maxValue = maxEXP;
        expSlider.value = currentEXP;

        levelText.text = "" + PlayerData.Level;
        healthText.text = currentHealth + " / " + maxHealth;
        expText.text = currentEXP + " / " + maxEXP;
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {

    }

    public void UpdatePlayerData()
    {
        PlayerData.CurrentHealth = currentHealth;
        PlayerData.CurrentEXP = currentEXP;
        PlayerData.Highscore = score;
    }

    public void UpdatePlayerStatus()
    {
        currentHealth += PlayerData.GetMaxHealth() - maxHealth;
        maxHealth = PlayerData.GetMaxHealth();
        currentHealth += Mathf.RoundToInt((maxHealth - currentHealth) * EndofLevelHeal);

        healthText.text = currentHealth + " / " + maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int value)
    {
        currentHealth -= value;

        if(currentHealth < 1)
        {
            currentHealth = 0;
            isDead = true;
            GetComponent<ThirdPersonMovement>().Death();
        }

        healthText.text = currentHealth + " / " + maxHealth;
        healthSlider.value = currentHealth;
    }

    public void GainEXP(int value)
    {
        int gainExp = Mathf.RoundToInt(value * expMultiplier);
        currentEXP += gainExp;
        score += gainExp;
        
        while(currentEXP >= maxEXP)
        {
            currentEXP -= maxEXP;
            LevelUp();
        }

        scoreText.text = "Score: " + score;
        expText.text = currentEXP + " / " + maxEXP;
        expSlider.value = currentEXP;
    }

    public void LevelUp()
    {
        PlayerData.LevelUp();
        levelText.text = "" + PlayerData.Level;
    }

}

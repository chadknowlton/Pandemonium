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
    

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;

    [SerializeField]
    private int maxEXP;
    [SerializeField]
    private int currentEXP;

    void Start()
    {
        maxHealth = PlayerData.GetMaxHealth();
        currentHealth = PlayerData.CurrentHealth;
        maxEXP = PlayerData.GetMaxEXP();
        currentEXP = PlayerData.CurrentEXP;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        expSlider.maxValue = maxEXP;
        expSlider.value = currentEXP;

        healthText.text = currentHealth + " / " + maxHealth;
        expText.text = currentEXP + " / " + maxEXP;
    }

    private void Update()
    {
        if (Input.GetKeyUp("r"))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyUp("y"))
        {
            Debug.Log("GAINEXP");
            GainEXP(101);
        }
    }

    public void TakeDamage(int value)
    {
        currentHealth -= value;

        if(currentHealth < 1)
        {
            Debug.Log("GAME OVER");
        }
        else
        {
            healthText.text = currentHealth + " / " + maxHealth;
            healthSlider.value = currentHealth;
        } 
    }

    public void GainEXP(int value)
    {
        currentEXP += value;
        
        if(currentEXP >= maxEXP)
        {
            currentEXP -= maxEXP;

            Debug.Log("LEVEL UP");
        }

        expText.text = currentEXP + " / " + maxEXP;
        expSlider.value = currentEXP;
    }

}

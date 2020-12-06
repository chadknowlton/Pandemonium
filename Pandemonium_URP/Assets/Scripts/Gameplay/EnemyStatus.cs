using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyStatus : MonoBehaviour
{
    private EnemyData data;

    public Slider healthslider;
    public TMP_Text healthText;

    public bool isDead = false;

    void Start()
    {
        data = GetComponent<EnemyData>();

        healthslider.maxValue = data.maxHealth;
        healthslider.value = data.health;
        healthText.text = data.health + " / " + data.maxHealth;
    }

    public void AttackPlayer(Collider other)
    {
        if(!PlayerStatus.isDead)
        {
            other.gameObject.GetComponent<PlayerStatus>().TakeDamage(data.damage);
        }
    }
    public void TakeDamage(int value)
    {
        if (!isDead)
        {
            data.health -= value;

            if (data.health < 1)
            {
                data.health = 0;
                isDead = true;
                
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().GainEXP(data.expGain);
                GetComponent<EnemyController>().Die();
                GameObject.Find("GameManager").GetComponent<GameManager>().AnEnemyDied();
                
            }

            healthslider.value = data.health;
            healthText.text = data.health + " / " + data.maxHealth;
        }
    }

}

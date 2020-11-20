using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyStatus : MonoBehaviour
{
    private EnemyData data;
    private Slider healthslider;
    private TMP_Text healthText;

    public float aggroRange;
    public bool isDead = false;

    void Start()
    {
        data = GetComponent<EnemyData>();
        healthslider = transform.GetChild(2).GetChild(0).GetComponent<Slider>();
        healthText  = transform.GetChild(2).GetChild(0).GetChild(3).GetComponent<TMP_Text>();
        aggroRange = data.aggroRange;

        healthslider.maxValue = data.maxHealth;
        healthslider.value = data.health;
        healthText.text = data.health + " / " + data.maxHealth;
    }

    public void AttackPlayer(Collider other)
    {
        other.gameObject.GetComponent<PlayerStatus>().TakeDamage(data.damage);
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
            }

            healthslider.value = data.health;
            healthText.text = data.health + " / " + data.maxHealth;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public string enemyName;

    public char rank;
    public int health;
    public int maxHealth;
    public int damage;
    public int expGain;
    public float aggroRange; 
    public float movementSpeed;
    public float stunDelay;

    private void Start()
    {
        if (enemyName == "Slime")
        {
            GetSlimeStats();
        }
        else if (enemyName == "Big Slime")
        {
            GetBigSlimeStats();
        }
        else if (enemyName == "Big Slime Blue")
        {
            GetBigSlimeBlueStats();
        }
        else if (enemyName == "Big Slime Black")
        {
            GetBigSlimeBlackStats();
        }
        else
        {
            GetBossStats();
        }
    }

    private void GetSlimeStats()
    {
        int randomHealth = Random.Range(6, 12);
        int randomDamage = Random.Range(1, 2);
        rank = 'D';
        health = randomHealth;
        maxHealth = randomHealth;
        damage = randomDamage;
        expGain = maxHealth + Random.Range(-1 * damage, damage);
        aggroRange = 15f;
        movementSpeed = 5f;
        stunDelay = 1f;
    }

    private void GetBigSlimeStats()
    {
        int randomHealth = Random.Range(15, 25);
        int randomDamage = Random.Range(2, 4);
        rank = 'C';
        health = randomHealth;
        maxHealth = randomHealth;
        damage = randomDamage;
        expGain = maxHealth + Random.Range(-1 * damage, damage);
        aggroRange = 20f;
        movementSpeed = 2.5f;
        stunDelay = 1f;
    }

    private void GetBigSlimeBlueStats()
    {
        int randomHealth = Random.Range(30, 35);
        int randomDamage = Random.Range(4, 6);
        rank = 'B';
        health = randomHealth;
        maxHealth = randomHealth;
        damage = randomDamage;
        expGain = maxHealth * 2 - Random.Range( 1, damage) * 3;
        aggroRange = 25f;
        movementSpeed = 3.5f;
        stunDelay = 1f;
    }

    private void GetBigSlimeBlackStats()
    {
        int randomHealth = Random.Range(50, 55);
        int randomDamage = Random.Range(8, 9);
        rank = 'A';
        health = randomHealth;
        maxHealth = randomHealth;
        damage = randomDamage;
        expGain = maxHealth * 2 + Random.Range(-1 * damage, damage);
        aggroRange = 30f;
        movementSpeed = 4f;
        stunDelay = 1f;
    }

    private void GetBossStats()
    {
        rank = 'S';
        health = 150;
        maxHealth = 150;
        damage = 15;
        expGain = 500;
        aggroRange = 50f;
        movementSpeed = 4f;
        stunDelay = .8f;
    }

}

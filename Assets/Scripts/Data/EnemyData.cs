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
    }

    private void GetSlimeStats()
    {
        rank = 'D';
        health = 10;
        maxHealth = 10;
        damage = 1;
        expGain = 10;
        aggroRange = 15f;
        movementSpeed = 5f;
        stunDelay = 1f;
    }

    private void GetBigSlimeStats()
    {
        rank = 'C';
        health = 20;
        maxHealth = 20;
        damage = 3;
        expGain = 20;
        aggroRange = 20f;
        movementSpeed = 2.5f;
        stunDelay = 1f;
    }

    private void GetBigSlimeBlueStats()
    {
        rank = 'B';
        health = 30;
        maxHealth = 30;
        damage = 5;
        expGain = 50;
        aggroRange = 25f;
        movementSpeed = 3.5f;
        stunDelay = 1f;
    }

    private void GetBigSlimeBlackStats()
    {
        rank = 'A';
        health = 50;
        maxHealth = 50;
        damage = 8;
        expGain = 100;
        aggroRange = 30f;
        movementSpeed = 4f;
        stunDelay = 1f;
    }

}

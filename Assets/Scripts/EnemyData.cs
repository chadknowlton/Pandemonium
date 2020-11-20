using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public string enemyName;

    public int health;
    public int maxHealth;
    public int damage;
    public int expGain;
    public float aggroRange; 
    public float movementSpeed;

    private void Start()
    {
        if(enemyName == "Slime")
        {
            GetSlimeStats();
        }
    }

    private void GetSlimeStats()
    {
        health = 10;
        maxHealth = 10;
        damage = 1;
        expGain = 10;
        aggroRange = 15f;
        movementSpeed = 4f;
    }

}

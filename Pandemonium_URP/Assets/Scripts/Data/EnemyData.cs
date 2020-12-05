using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public string enemyName;


    [HideInInspector] public char rank;
    [HideInInspector] public int health;
    [HideInInspector] public int maxHealth;
    [HideInInspector] public int damage;
    [HideInInspector] public int expGain;
    [HideInInspector] public float aggroRange;
    [HideInInspector] public float movementSpeed;
    [HideInInspector] public float stunDelay;

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
        else if (enemyName == "Grunt")
        {
            GetGruntStats();
        }
        else if (enemyName == "Golem")
        {
            GetGolemStats();
        }
        else if (enemyName == "GiantBug")
        {
            GetGiantBugStats();
        }
        else if (enemyName == "Dragon")
        {
            GetDragonStats();
        }
    }

    private void GetSlimeStats()
    {
        rank = 'D';
        aggroRange = 25f;
        movementSpeed = 5f;
        stunDelay = 1f;

        int minTempHealth = 6;
        int maxTempHealth = 12;
        int minTempDamage = 1;
        int maxTempDamage = 2;

        maxHealth = Random.Range(minTempHealth, maxTempHealth);
        health = maxHealth;
        damage = Random.Range(minTempDamage, maxTempDamage);
        expGain = maxHealth + Random.Range((-1 * damage), damage);
    }

    private void GetBigSlimeStats()
    {
        rank = 'C';
        aggroRange = 30f;
        movementSpeed = 3f;
        stunDelay = 1f;

        int minTempHealth = 20;
        int maxTempHealth = 25;
        int minTempDamage = 5;
        int maxTempDamage = 7;

        maxHealth = Random.Range(minTempHealth, maxTempHealth);
        health = maxHealth;
        damage = Random.Range(minTempDamage, maxTempDamage);
        expGain = maxHealth + Random.Range((-1 * damage), damage);
    }

    private void GetGruntStats()
    {
        rank = 'C';
        aggroRange = 35f;
        movementSpeed = 4f;
        stunDelay = 2f;

        int minTempHealth = 20;
        int maxTempHealth = 25;
        int minTempDamage = 5;
        int maxTempDamage = 7;

        maxHealth = Random.Range(minTempHealth, maxTempHealth);
        health = maxHealth;
        damage = Random.Range(minTempDamage, maxTempDamage);
        expGain = maxHealth + Random.Range((-1 * damage), damage);
    }

    private void GetGolemStats()
    {
        rank = 'B';
        aggroRange = 40f;
        movementSpeed = 3f;
        stunDelay = 2.5f;

        int minTempHealth = 50;
        int maxTempHealth = 75;
        int minTempDamage = 10;
        int maxTempDamage = 15;

        maxHealth = Random.Range(minTempHealth, maxTempHealth);
        health = maxHealth;
        damage = Random.Range(minTempDamage, maxTempDamage);
        expGain = maxHealth + Random.Range((-1 * damage), damage);
    }

    private void GetGiantBugStats()
    {
        rank = 'A';
        aggroRange = 45f;
        movementSpeed = 3f;
        stunDelay = 2f;

        int minTempHealth = 100;
        int maxTempHealth = 125;
        int minTempDamage = 20;
        int maxTempDamage = 30;

        maxHealth = Random.Range(minTempHealth, maxTempHealth);
        health = maxHealth;
        damage = Random.Range(minTempDamage, maxTempDamage);
        expGain = maxHealth + Random.Range((-1 * damage), damage);
    }

    private void GetDragonStats()
    {
        rank = 'S';
        aggroRange = 100f;
        movementSpeed = 8f;
        stunDelay = 3f;

        int minTempHealth = 700;
        int maxTempHealth = 800;
        int minTempDamage = 50;
        int maxTempDamage = 75;

        maxHealth = Random.Range(minTempHealth, maxTempHealth);
        health = maxHealth;
        damage = Random.Range(minTempDamage, maxTempDamage);
        expGain = maxHealth + Random.Range((-1 * damage), damage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    //Max Health = 10 * consititution
    //Range = 1 + (10% of intelligence)
    //ProjectileSpeed = 10 + (triple of Dexterity)
    //MovementSpeed = 5 + (10% of Dexterity)
    //ShootingDamage = 2 * intelligence;
    //ShootingDelay = 1 - (5% of Dexterity);
    //Defense = Defense % reduction to damage

    //Player Stats
    private static int level = 1;
    private static int intelligence = 10;
    private static int defense = 10;
    private static int constitution = 10;
    private static int dexterity = 10;
    private static int skillIncrement = 1;

    //Game Variable
    private static int highScore = 0;
    private static int maxhealth = 10;
    private static int curhealth = 10;
    private static int maxExp = 100;
    private static int curExp = 0;
    private static int skillPoints = 5;

    private static float movementSpeed = 5f;
    private static float jumpspeed = 2f;

    private static float projectileRange = 0.5f;
    private static float projectileSpeed = 10f;

    private static float shootDelay = 1f;

    public static void NewGame()
    {
        level = 1;
        intelligence = Random.Range(1, 3);
        defense = Random.Range(1, 3);
        constitution = Random.Range(1, 3);
        dexterity = Random.Range(1, 3);
        skillIncrement = 1;

        highScore = 0;
        maxhealth = 10 + Random.Range(1, 5);
        curhealth = GetMaxHealth();
        maxExp = 100;
        curExp = 0;
        skillPoints = 0;

        movementSpeed = 5f;
        jumpspeed = 2f;

        projectileRange = 1f;
        projectileSpeed = 10f;

        shootDelay = .75f;
    }

    public static int[] GetForStatsScreen()
    {
        int[] ret = { highScore, level, skillPoints, intelligence, defense, constitution, dexterity };
        return ret;
    }

    public static void SetFrorStatsScreen(int[] values)
    {
        skillPoints = values[2];
        intelligence = values[3];
        defense = values[4];
        constitution = values[5];
        dexterity = values[6];
    }

    public static int GetMaxHealth()
    {
        return maxhealth * constitution;
    }
    public static int GetMaxEXP()
    {
        return maxExp;
    }
    public static int Level
    {
        get { return level; }
    }

    public static int SkillPoint
    {
        get { return skillPoints; }
    }

    public static int Highscore
    {
        get { return highScore; }
        set { highScore = value; }
    }

    public static int CurrentHealth
    {
        get { return curhealth; }
        set { curhealth = value; }
    }

    public static int CurrentEXP
    {
        get { return curExp; }
        set { curExp = value; }
    }

    public static float ShootingDelay
    {
        get { return shootDelay - (dexterity * 0.01f); }
    }

    public static int GetDefense()
    {
        return defense;
    }

    public static float GetMovementSpeed()
    {
        return movementSpeed + (dexterity * 0.1f);
    }

    public static float GetJumpSpeed()
    {
        return jumpspeed;
    }

    public static float GetShootingRange()
    {
        return projectileRange + (0.05f * intelligence);
    }

    public static float GetProjectileSpeed()
    {
        return projectileSpeed + (3 * dexterity);
    }

    public static int GetShootingDamage()
    {
        return 2 * intelligence;
    }

    public static void LevelUp()
    {
        level++;
        skillPoints += skillIncrement;
    }
}

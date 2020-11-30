using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    //Max Health = 10 * consititution
    //Range = 1 + (10% of intelligence)
    //ProjectileSpeed = 10 + (Double of Dexterity)
    //MovementSpeed = 5 + (10% of Dexterity)
    //ShootingDamage = 2 * intelligence;
    //ShootingDelay = 1 - (10% of Dexterity);

    //Player Stats
    private static int level = 1;
    private static int intelligence = 10;
    private static int defense = 10;
    private static int constitution = 10;
    private static int dexterity = 10;
    private static int skillPoints = 5;
    private static int skillIncrement = 1;

    //Game Variable
    private static int highScore = 0;
    private static int maxhealth = 10;
    private static int curhealth = 10;
    private static int maxExp = 100;
    private static int curExp = 0;

    private static float movementSpeed = 5f;
    private static float jumpspeed = 2f;

    private static float projectileRange = 0.5f;
    private static float projectileSpeed = 10f;

    private static float shootDelay = 1f;

    public static void NewGame()
    {
        //Max Health = 10 * consititution
        //Range = 1 + (10% of intelligence)
        //ProjectileSpeed = 10 + (Double of Dexterity)
        //MovementSpeed = 5 + (10% of Dexterity)
        //ShootingDamage = 2 * intelligence;
        //ShootingDelay = 1 - (10% of Dexterity);

        level = 1;
        intelligence = Random.Range(1, 2);
        defense = Random.Range(1, 3);
        constitution = Random.Range(1, 3);
        dexterity = Random.Range(1, 2);
        skillPoints = 0;
        skillIncrement = 1;

        int tempHealth = (int)(10 * (float)constitution * Random.Range(.6f, .8f));
        if (tempHealth < 10)
        {
            tempHealth = 10;
        }

        highScore = 0;
        maxhealth = tempHealth;
        curhealth = tempHealth;
        maxExp = 100;
        curExp = 0;

        movementSpeed = 5f + (dexterity * .15f);
        jumpspeed = 2f;

        projectileRange = 0.1f * intelligence;
        projectileSpeed = 10f + (dexterity * 2);

        shootDelay = 1f - (.075f * dexterity);
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
        get { return shootDelay - (dexterity * 0.1f); }
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
        return projectileRange + (0.1f * intelligence);
    }

    public static float GetProjectileSpeed()
    {
        return projectileSpeed + (2 * dexterity);
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

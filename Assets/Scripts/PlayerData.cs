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

    //Player Stats
    private static int level = 1;
    private static int intelligence = 1;
    private static int defence = 1;
    private static int constitution = 1;
    private static int dexterity = 1;
    
    //Game Variable
    private static int maxhealth = 10;
    private static int curhealth = 10;
    private static int maxExp = 100;
    private static int curExp = 0;

    private static float movementSpeed = 5f;
    private static float jumpspeed = 2f;

    private static float projectileRange = 0.5f;
    private static float projectileSpeed = 10f;

    private static float shootDelay = 1f;

    public static int GetMaxHealth()
    {
        return maxhealth * constitution;
    }
    public static int GetMaxEXP()
    {
        return maxExp;
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
}

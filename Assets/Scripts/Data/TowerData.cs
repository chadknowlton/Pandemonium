using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TowerData
{
    public static bool isRank = false;
    public static char rank = 'D';
    public static int ToSpawn = 1;
    public static float multiplier = 1f;

    private static int currentFloor = 1;
    private static int maxFloor = 10;

    /*private static int numofArank = 10;
    private static int numofBrank = 15;
    private static int numofCrank = 25;
    private static int numofDrank = 50;*/

    private static int numofArank = 100;
    private static int numofBrank = 100;
    private static int numofCrank = 2;
    private static int numofDrank = 2;

    private static int spawnMin = 1;
    private static int spawnLimitBase = 20;
    private static int spawnLimit = 20;

    public static void NewGame()
    {
        isRank = false;
        rank = 'D';
        ToSpawn = 1;
        multiplier = 1f;

        currentFloor = 1;
        maxFloor = 10;

        numofArank = 10;
        numofBrank = 15;
        numofCrank = 25;
        numofDrank = 50;

        spawnMin = 1;
        spawnLimit = 20;
    }
    public static int SpawnLimit { get { return spawnLimit; } }

    public static int CurrentFloor { get { return currentFloor; } }

    public static int MaxFloor { get { return maxFloor; } }

    public static int GetTotalMonsterLeft
    {
        get { return numofArank + numofBrank + numofCrank + numofDrank; }
    }

    public static int GetRemainingMonsterleft(char rank)
    {
        int num = 0;

        if (rank == 'D')
        {
            num = numofDrank;
        }
        else if (rank == 'C')
        {
            num = numofCrank;
        }
        else if (rank == 'B')
        {
            num = numofBrank;
        }
        else if (rank == 'A')
        {
            num = numofArank;
        }

        return num;
    }

    public static void RemoveMonster(char rank, int num)
    {
        if (rank == 'D')
        {
            numofDrank -= num;
        }
        else if (rank == 'C')
        {
            numofCrank -= num;
        }
        else if (rank == 'B')
        {
            numofBrank -= num;
        }
        else if (rank == 'A')
        {
            numofArank -= num;
        }
    }

    public static void NextFloor()
    {
        currentFloor++;
    }


    public static int GetMin()
    {
        int total = numofArank + numofBrank + numofCrank + numofDrank;
        int floorLeft = maxFloor - (currentFloor - 1);
        int fullFloor = total / spawnLimit;

        if ((floorLeft - fullFloor) > 1)
        {
            spawnMin = 1;
        }
        else if ((floorLeft - fullFloor) == 1)
        {

            spawnMin = total % spawnLimit;
        }
        else
        {
            spawnMin = spawnLimit;
        }

        return spawnMin;
    }

    public static int GetMax()
    {
        int total = numofArank + numofBrank + numofCrank + numofDrank;
        int floorLeft = maxFloor - (currentFloor - 1);

        total -= floorLeft;

        if(total < spawnLimitBase - 1)
        {
            spawnLimit = total + 1;
        }
        else
        {
            spawnLimit = spawnLimitBase;
        }

        return spawnLimit;
    }
}


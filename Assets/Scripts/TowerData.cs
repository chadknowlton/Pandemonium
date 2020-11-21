using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TowerData
{
    public static bool isRank = false;
    public static char rank = 'A';
    public static int ToSpawn = 10;


    private static int numofArank = 10;
    private static int numofBrank = 15;
    private static int numofCrank = 25;
    private static int numofDrank = 50;

    private static int spawnLimit = 20;


    public static int SpawnLimit { get { return spawnLimit; } }

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
}


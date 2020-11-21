using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public bool isRank;
    public char rank;
    public int numToSpawn;

    public Transform[] spawnPoints;
    public GameObject[] aMonsterPrefabs;
    public GameObject[] bMonsterPrefabs;
    public GameObject[] cMonsterPrefabs;
    public GameObject[] dMonsterPrefabs;

    void Start()
    {
        isRank = TowerData.isRank;
           
        if(isRank)
        {
            rank = TowerData.rank;

            numToSpawn = (int)(Random.Range(1f, TowerData.GetRemainingMonsterleft(rank) + 0.99f));
            
            if(numToSpawn > TowerData.SpawnLimit)
            {
                numToSpawn = TowerData.SpawnLimit;
            }

            TowerData.RemoveMonster(rank, numToSpawn);

            StartCoroutine(RankSpawn(numToSpawn, GetMonsterList(rank)));
        }
        else
        {
            numToSpawn = TowerData.ToSpawn;
            StartCoroutine(NumberSpawn(numToSpawn));
        }
    }

    // Update is called once per frame

    private IEnumerator RankSpawn(int numToSpawn, GameObject[] monsterList)
    {
        while (numToSpawn > 0)
        {
            int point = (int)Random.Range(0f, monsterList.Length - 0.01f);
            GameObject monster = Instantiate(monsterList[point]);

            point = (int)Random.Range(0f, spawnPoints.Length - 0.01f);
            monster.transform.position = spawnPoints[point].position;

            numToSpawn--;
            yield return null;
            //yield return new WaitForSeconds(1f);
        }

        Debug.Log("LEFT: " + TowerData.GetTotalMonsterLeft);
    }

    private IEnumerator NumberSpawn(int numToSpawn)
    {
        char[] rank = { 'D', 'C', 'B', 'A' };
        int num, limit;
        int leftToSpawn = numToSpawn;

        for(int i = 0; i < rank.Length; i++)
        {
            limit = TowerData.GetRemainingMonsterleft(rank[i]);

            if (limit > 0 && leftToSpawn > 0)
            {
                if(limit > leftToSpawn)
                {
                    limit = leftToSpawn;
                }

                num = (int)Random.Range(1f, limit + 0.99f);
                leftToSpawn -= num;
                TowerData.RemoveMonster(rank[i], num);

                StartCoroutine(RankSpawn(num, GetMonsterList(rank[i])));
            }

            //yield return null;
            yield return new WaitForSeconds(1f);
        }

        if(leftToSpawn > 0)
        {
            StartCoroutine(NumberSpawn(leftToSpawn));
        }
    }

    private GameObject[] GetMonsterList(char rank)
    {
        GameObject[] list = null;

        if (rank == 'D')
        {
            list = dMonsterPrefabs;
        }
        else if (rank == 'C')
        {
            list = cMonsterPrefabs;
        }
        else if (rank == 'B')
        {
            list = bMonsterPrefabs;
        }
        else if (rank == 'A')
        {
            list = aMonsterPrefabs;
        }

        return list;
    }
}

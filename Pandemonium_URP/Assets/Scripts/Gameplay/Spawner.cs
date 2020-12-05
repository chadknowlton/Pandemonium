using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public bool isRank;
    public bool isBoss;
    public char rank;
    public int numToSpawn;

    public Transform playerPosition;
    public Transform[] spawnPoints;
    public GameObject[] sMonsterPrefabs;
    public GameObject[] aMonsterPrefabs;
    public GameObject[] bMonsterPrefabs;
    public GameObject[] cMonsterPrefabs;
    public GameObject[] dMonsterPrefabs;


    void Start()
    {
        int rankLimit = 0;
        isRank = TowerData.isRank;
        isBoss = TowerData.isBoss;
        
        if(isBoss)
        {
            StartCoroutine(RankSpawn(1, sMonsterPrefabs));
        }
        else if(isRank)
        {
            rank = TowerData.rank;

            numToSpawn = (int)(Random.Range(1f, TowerData.GetRemainingMonsterleft(rank) + 0.99f));
            rankLimit = TowerData.GetMax();

            if (numToSpawn > rankLimit)
            {
                numToSpawn = rankLimit;
            }

            rankLimit = TowerData.GetMin();

            if (numToSpawn < rankLimit)
            {
                numToSpawn = rankLimit;
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
            int mPoint = (int)Random.Range(0f, monsterList.Length - 0.01f);
            int sPoint = (int)Random.Range(0f, spawnPoints.Length - 0.01f);

            Vector3 spawnLocation = spawnPoints[sPoint].position;
            Vector3 randomPoint = Random.insideUnitSphere * 5;

            randomPoint = new Vector3(randomPoint.x, spawnLocation.y, randomPoint.z);
            spawnLocation += randomPoint;

            GameObject monster = Instantiate(monsterList[mPoint], spawnLocation, Quaternion.identity);
            
            monster.transform.LookAt(playerPosition);
            numToSpawn--;

            yield return null;
        }
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

            yield return null;
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

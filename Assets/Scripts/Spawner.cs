using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    public Transform[] spawnPoints;

    float numToSpawn = 5;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        float point = Random.Range(0.01f, monsterPrefabs.Length) - 0.01f;
        GameObject monster = Instantiate(monsterPrefabs[(int)point]);

        point = Random.Range(0.01f, spawnPoints.Length) - 0.01f;
        monster.transform.position = spawnPoints[(int)point].position;

        numToSpawn--;

        yield return new WaitForSeconds(1f);

        if(numToSpawn > 0)
        {
            StartCoroutine(Spawn());
        }

    }
}

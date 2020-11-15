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
        GameObject monster = Instantiate(monsterPrefabs[0]);
        float point = Random.Range(0f, 4f) / 1;

        monster.transform.position = spawnPoints[(int)point].position;


        yield return new WaitForSeconds(1f);
        numToSpawn--;

        if(numToSpawn > 0)
        {
            StartCoroutine(Spawn());
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool isPausedStats = false;

    public float getCountDelay = 1f;

    private int enemyCount;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(GetEnemyCount());
    }

    void Update()
    {

    }

    public void AnEnemyDied()
    {
        enemyCount--;

        if (enemyCount < 1)
        {
            StartCoroutine(AllEnemyKilled());
        }
    }

    private IEnumerator GetEnemyCount()
    {
        yield return new WaitForSeconds(getCountDelay);

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private IEnumerator AllEnemyKilled()
    {
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().UpdatePlayerData();
        GetComponent<LevelUpMenu>().startLevelUp();
    }
}

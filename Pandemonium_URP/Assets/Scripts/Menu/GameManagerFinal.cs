using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFinal : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool isPausedStats = false;

    private int enemyCount;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

    private IEnumerator AllEnemyKilled()
    {
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().UpdatePlayerData();
    }
}

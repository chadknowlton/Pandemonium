using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool isPausedStats = false;

    public float getCountDelay = 1f;
    public GameObject portal;
    public TMP_Text floorLabel;

    private int enemyCount;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        portal.SetActive(false);

        StartCoroutine(GetEnemyCount());
        StartCoroutine(FloorLabel());
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
        portal.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().UpdatePlayerData();
        GetComponent<LevelUpMenu>().startLevelUp();
    }

    private IEnumerator FloorLabel()
    {
        floorLabel.text = "FLOOR: " + TowerData.CurrentFloor;

        yield return new WaitForSeconds(3f);

        floorLabel.gameObject.SetActive(false);
    }
}

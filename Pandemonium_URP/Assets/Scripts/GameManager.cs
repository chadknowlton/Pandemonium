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
            if(TowerData.isBoss)
            {
                StartCoroutine(BossKilled());
            }
            else
            {
                StartCoroutine(AllEnemyKilled());
            }
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

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerStatus>().UpdatePlayerData();
        GetComponent<LevelUpMenu>().startLevelUp();

        portal.SetActive(true);

        Vector3 dir = portal.transform.position - player.transform.position;
        dir = dir.normalized;

        Vector3 loc = player.transform.position + (dir * 25);
        loc = new Vector3(loc.x, portal.transform.position.y, loc.z);

        portal.transform.position = loc;
        portal.transform.LookAt(player.transform);
    }

    private IEnumerator BossKilled()
    {
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().UpdatePlayerData();
        StartCoroutine(GetComponent<WinScript>().WinGame());
    }

    private IEnumerator FloorLabel()
    {
        if(TowerData.isBoss)
        {
            floorLabel.text = "Final Floor";
        }
        else
        {
            floorLabel.text = "FLOOR: " + TowerData.CurrentFloor;
        }

        yield return new WaitForSeconds(3f);

        floorLabel.gameObject.SetActive(false);
    }
}

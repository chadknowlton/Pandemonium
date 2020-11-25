using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private EnemyStatus enemyStatus;

    // Start is called before the first frame update
    void Start()
    {
        enemyStatus = GetComponentInParent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyStatus.AttackPlayer(other);
        }
    }
}

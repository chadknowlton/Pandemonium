using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    private float health = 5;

    public bool isDead { get; set; }

    void Update()
    {
        if(health <= 0 && !isDead)
        {
            isDead = true;
            GetComponent<EnemyController>().Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ProjectilePlayer")
        {
            health--;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rbody;
    private float health = 5;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
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

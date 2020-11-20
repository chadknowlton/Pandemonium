using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float lifetime;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        lifetime = PlayerData.GetShootingRange();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LifeTime(lifetime));
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyStatus>().TakeDamage(damage);


            Destroy(gameObject);
        }
    }

    private IEnumerator LifeTime(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

}

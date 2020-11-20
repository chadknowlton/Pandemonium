using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform hand;

    [SerializeField]
    private Transform aim;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int damage;

    void Start()
    {
        speed = PlayerData.GetProjectileSpeed();
        aim = transform.GetChild(2).GetComponent<Transform>();
        damage = PlayerData.GetShootingDamage();
    }


    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            StartCoroutine(Fire());
        }

    }

    private IEnumerator Fire()
    {

        yield return null;

        Vector3 mid = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        Ray ray = new Ray(mid, Camera.main.transform.forward);

        Vector3 aimedObject;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            aimedObject = hit.point;
        }
        else
        {
            aimedObject = ray.origin + ray.direction * 100f;
        }

        ray = new Ray(hand.position, aimedObject - hand.position);

        Debug.DrawRay(hand.position, ray.direction * 100f, Color.red, 10f);

        GameObject projectile = Instantiate(projectilePrefab);
        Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());

        projectile.GetComponent<Projectile>().damage = damage;
        projectile.transform.position = hand.position;
        projectile.transform.rotation = Quaternion.LookRotation(ray.direction, Vector3.up);
        projectile.GetComponent<Rigidbody>().AddForce(ray.direction * speed, ForceMode.Impulse);
    }

}

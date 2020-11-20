using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    private Rigidbody rbody;
    private Animator animator;
    private NavMeshAgent ai;
    private EnemyStatus status;

    private Transform playerTransform;

    private float movement;
    private float aggroRadius;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Wizard").transform;
        animator = GetComponent<Animator>();
        ai = GetComponent<NavMeshAgent>();
        rbody = GetComponent<Rigidbody>();
        status = GetComponent<EnemyStatus>();

        movement = 0f;
        aggroRadius = status.aggroRange;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (aggroRadius > distance && !status.isDead)
        {
            if (ai.stoppingDistance >= distance)
            {
                Attack();
            }
            else
            {
                MoveForward();
            }
        }
        else
        {
            StopMoving();
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ProjectilePlayer")
        {
            rbody.velocity = Vector3.zero;
            movement = 0f;
            ai.SetDestination(transform.position);
            animator.Play("GetHit");
        }
    }

    void MoveForward()
    {
        movement += Time.deltaTime;
        ai.SetDestination(playerTransform.position);
        animator.SetFloat("Forward", movement);
    }

    void StopMoving()
    {
        movement = 0f;
        ai.SetDestination(transform.position);
        animator.SetFloat("Forward", movement);
    }

    void Attack()
    {
        movement = 0f;
        Vector3 dir = playerTransform.position - transform.position;
        dir = dir.normalized;
        dir.y = 0f;

        Quaternion rot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 5f);
        ai.SetDestination(transform.position);
        animator.Play("Attack");
    }

    public void Die()
    {
        movement = 0f;
        ai.SetDestination(transform.position);
        animator.Play("Die");
        Destroy(gameObject, 1f);
    }
}

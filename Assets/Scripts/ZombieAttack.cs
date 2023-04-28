using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int damageAmount = 1;
    float attackRange = 2f;
    float attackRate = 4.0f;

    private Transform playerTransform;
    private float nextAttackTime;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        CheckForAttack();

    }


    void CheckForAttack()
    {
        float dist = Vector3.Distance(transform.position, playerTransform.position);
        //print("dist=" + dist);

        if (Vector3.Distance(transform.position, playerTransform.position) < attackRange )
        {
            //print("time=" + Time.time + "  next=" + nextAttackTime);
            if (Time.time >= nextAttackTime)
            {
                DoAttack();
                nextAttackTime = Time.time + attackRate;
            }
        }
    }

    private void DoAttack()
    {
        print("do attack");
        PlayerHealth playerHealth = playerTransform.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
        else
        {
            print("script is null");
        }    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieAttack : MonoBehaviour
{
    float attackRange = 2f;
    float attackRate = 4.0f;

    private Transform playerTransform;
    private float nextAttackTime;
    private int currentHealth;
    public int damageAmount = 1;
    public HealthBar healthBar;

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

    public void DoAttack()
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);


        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Death");
            Time.timeScale = 0f;
        }
    }


}

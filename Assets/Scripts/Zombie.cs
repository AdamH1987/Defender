using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Zombie : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 2.0f;
    public float stoppingDistance = 2.0f;
    public float retreatDistance = 1.0f;
    [SerializeField] private float initialHealth = 100f;
    private float currentHealth;


    private void Start()
    {
        currentHealth = initialHealth;
    }

    void Update()
    {
        if (Player == null)
        {
            return;
        }

        if (Vector3.Distance(transform.position, Player.position) > stoppingDistance)
        {
            transform.LookAt(Player);
            transform.position = Vector3.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, Player.position) < stoppingDistance && Vector3.Distance(transform.position, Player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, Player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, -moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
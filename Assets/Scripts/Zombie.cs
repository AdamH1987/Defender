using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 2.0f;
    public int maxHealth = 100;
    public int currentHealth;

    private Transform player;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        // Move towards the player
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // Prevent zombie from tilting
        direction.Normalize(); // Prevent faster movement when moving diagonally
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

        // Rotate towards the player
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

        // Prevent the zombie from walking through objects
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
        {
            if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Player") && hit.collider.gameObject.layer != LayerMask.NameToLayer("Bullet"))
            {
                direction = hit.normal;
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            }
        }

        // Keep the zombie on the ground
        RaycastHit groundHit;
        if (Physics.Raycast(transform.position, -Vector3.up, out groundHit, 1.0f))
        {
            if (groundHit.distance > 0.1f)
            {
                rb.AddForce(Vector3.down * 10.0f, ForceMode.Acceleration);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

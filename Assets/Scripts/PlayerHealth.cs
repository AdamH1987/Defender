using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int PmaxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = PmaxHealth;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            print("man I'm dead");
            Time.timeScale = 0;
        }
    }
}

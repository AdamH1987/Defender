using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int PmaxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = PmaxHealth;
        healthBar.SetHealth(currentHealth);
    }

    private void Update()
    {
        if (Input.GetKey("p"))
        {
            SceneManager.LoadScene("Main menu");
        }
        

    }
}

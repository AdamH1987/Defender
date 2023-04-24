using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public Text abilityText1;
    public KeyCode ability1Key;
    public float ability1Cooldown = 5;
    public ParticleSystem partSys;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    private bool isAbility1Cooldown = false;
    private float currentAbility1Cooldown;


    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityText1.text = "";
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        Ability1Input();
        AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, abilityImage1, abilityText1);
        print(isAbility1Cooldown);

        if (Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(20);
        }
  
    }

    private void Ability1Input()
    {
        if (Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        {
            isAbility1Cooldown = true;
            currentAbility1Cooldown = ability1Cooldown;
            HealDamage(20);
            Effect();

        }
    }

    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;

                if (skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if (skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if (skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if (skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }

    void HealDamage(int heal)
    {
        if (currentHealth == 100)
        {
            return;
        }
        else
        {
            currentHealth += heal;

            healthBar.SetHealth(currentHealth);
        }
    }

    void Effect()
    {
        print("play particle system");
        if (partSys != null)
        {
            partSys.Stop();
            var particleDuration = partSys.main;
            particleDuration.duration = 2f;

            partSys.Play();
        }
        else
        {
            print("Error, no particle component found");
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

}
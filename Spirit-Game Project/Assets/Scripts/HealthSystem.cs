using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    public HealthSystemUI healthSystemUI;

    public static HealthSystem instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        currentHealth = maxHealth;

        healthSystemUI.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthSystemUI.SetCurrentHealth(currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    public void Heal(int heal)
    {
        currentHealth += heal;

        healthSystemUI.SetCurrentHealth(currentHealth);
    }

    public void Die()
    {
        Debug.Log("You are died.");
    }
}

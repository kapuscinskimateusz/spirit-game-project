using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    public PlayerHealthUI healthSystemUI;

    public static HealthManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        ResetHealth();

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

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthSystemUI.SetCurrentHealth(currentHealth);
    }

    public void Die()
    {
        GameManager.instance.GameIsOver = true;

        Debug.Log("You are died.");
    }
}


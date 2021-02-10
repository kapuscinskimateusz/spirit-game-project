using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    public HealthSystemUI healthSystemUI;
    private Transform player;

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

        if (currentHealth > 0)
        {
            player = GameObject.Find("Player").transform;
            player.position = GameManager.instance.lastCheckPointPos;
        }
        else
            Die();
    }

    public void Heal(int heal)
    {
        currentHealth += heal;

        healthSystemUI.SetCurrentHealth(currentHealth);
    }

    public void Die()
    {
        currentHealth = 0;
        healthSystemUI.SetCurrentHealth(currentHealth);

        GameManager.instance.GameOver();

        Debug.Log("You are died.");
    }
}

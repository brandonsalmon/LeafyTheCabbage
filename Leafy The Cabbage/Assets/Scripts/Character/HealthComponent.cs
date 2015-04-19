using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour
{

    public int CurrentHealth = 100;
    public int MaxHealth = 100;
    public int MinimumHealth = 0;

    public bool IsDead
    {
        get
        {
            return CurrentHealth <= MinimumHealth;
        }
    }

    public bool Respawning { get; set; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateHealth(int amount)
    {
        var health = CurrentHealth += amount;

        if (health > MaxHealth)
        {
            CurrentHealth = 100;
        }
        else if (health < MinimumHealth)
        {
            CurrentHealth = MinimumHealth;
        }
        else
        {
            CurrentHealth = health;
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }

    public void Kill()
    {
        CurrentHealth = MinimumHealth;
    }
}

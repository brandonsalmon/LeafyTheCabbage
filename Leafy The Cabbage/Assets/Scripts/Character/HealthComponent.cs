using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour
{
	private AudioSource audio;

    public int CurrentHealth = 100;
    public int MaxHealth = 100;
    public int MinHealth = 0;

	public AudioClip takeDamageSound;

    public bool IsDead
    {
        get
        {
            return CurrentHealth <= MinHealth;
        }
    }

    public bool Respawning { get; set; }

    void Start()
    {
		this.audio = gameObject.GetComponent<AudioSource>();
    }

    public void UpdateHealth(int amount)
    {
        var newHealth = CurrentHealth + amount;

        if (newHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        else if (newHealth <= MinHealth)
        {
            CurrentHealth = MinHealth;
        }
        else
        {
			if (amount < 0)
			{
				this.audio.PlayOneShot(takeDamageSound);
			}
            CurrentHealth = newHealth;
        }
    }

    public void ResetHealth()
    {
		CurrentHealth = MaxHealth;
    }

    public void Kill()
    {
		CurrentHealth = MinHealth;
    }
}

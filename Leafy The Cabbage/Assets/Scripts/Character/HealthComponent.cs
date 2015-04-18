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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}

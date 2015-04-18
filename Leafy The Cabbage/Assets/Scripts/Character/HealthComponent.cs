using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour {

    public int CurrentHealth;
    public int MaxHealth;
    public int MinimumHealth;

    public bool IsDead
    {
        get
        {
            return CurrentHealth <= MinimumHealth;
        }
    }
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        CurrentHealth--;
	}
}

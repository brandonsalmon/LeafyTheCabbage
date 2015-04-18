using UnityEngine;
using UnityEngine.UI;
using LeafyTheCabbage.Domain.Character;
using System.Collections;

public class HealthBarController : MonoBehaviour
{
    public Text HealthBar;

	// Use this for initialization
	void Start () {
        HealthBar = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        HealthBar.text = "Health: " + this.GetComponent<HealthComponent>().CurrentHealth;
	}
}

﻿using UnityEngine;
using System.Collections;

public class PainController : MonoBehaviour
{
    public int Damage = -10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            var leafy = other.collider;
            leafy.GetComponent<HealthComponent>().UpdateHealth(Damage);
            var difference = leafy.transform.position - transform.position;
            leafy.GetComponent<Rigidbody2D>().AddForce(difference * 10, ForceMode2D.Impulse);
        }
    }
}

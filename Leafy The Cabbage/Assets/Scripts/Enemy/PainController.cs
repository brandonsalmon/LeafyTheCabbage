using UnityEngine;
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
            other.collider.GetComponent<HealthComponent>().UpdateHealth(Damage);
        }
    }
}

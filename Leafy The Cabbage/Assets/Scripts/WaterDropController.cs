using UnityEngine;
using System.Collections;

public class WaterDropController : MonoBehaviour
{

    public int Health = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            obj.GetComponent<HealthComponent>().UpdateHealth(Health);

            // TODO: play a noise

            // Remove this drop
            Destroy(gameObject);
        }
    }
}

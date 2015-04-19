using UnityEngine;
using System.Collections;

public class WaterDropController : MonoBehaviour
{

    public int Health = 10;

	public AudioClip healPlayerSound;

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
			obj.GetComponent<AudioSource>().PlayOneShot(healPlayerSound);

            // Remove this drop
            Destroy(gameObject);
        }
    }
}

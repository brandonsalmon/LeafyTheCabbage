using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Public variable 
    public int Force = 50;


    // Gets called once when the bullet is created
    void Start () {
        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(Vector2.right * Force, ForceMode2D.Impulse);
    }

    // Gets called when the object goes out of the screen
    void OnBecameInvisible() {  
        // Destroy the bullet 
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}

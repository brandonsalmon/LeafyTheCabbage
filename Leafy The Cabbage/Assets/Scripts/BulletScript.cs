using LeafyTheCabbage.Domain.Character;
using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Public variable 
    public int Force = 50;


    // Gets called once when the bullet is created
    void Start ()
    {
        var leafy = GameObject.FindWithTag("Player");
        var orientation = leafy.GetComponent<MoveController>().Orientation;

        var forceDirection = orientation == Orientation.Left ? (-1*Force) : Force;

        var rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(Vector2.right * forceDirection, ForceMode2D.Impulse);
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

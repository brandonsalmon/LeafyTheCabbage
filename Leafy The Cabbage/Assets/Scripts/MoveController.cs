using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float MaxAcceleration = 10f;

    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode LeftShift = KeyCode.LeftShift;

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var rigidBody = GetComponent<Rigidbody2D>();

	    if (Input.GetKey(LeftShift))
	    {
	        MaxAcceleration = 20f;
	    }

        if (Input.GetKey(LeftKey))
        {
            rigidBody.AddForce(Vector2.right * -MaxAcceleration, ForceMode2D.Force);
        }
        else if (Input.GetKey(RightKey))
        {
            rigidBody.AddForce(Vector2.right * MaxAcceleration, ForceMode2D.Force);
        }
	}
}

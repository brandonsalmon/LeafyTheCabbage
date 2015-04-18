using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float MaxAcceleration = 10f;

    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode LeftShift = KeyCode.LeftShift;

    public KeyCode PreviousKey;

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var rigidBody = GetComponent<Rigidbody2D>();
	    var acceleration = 1f;

	    if (Input.GetKey(LeftShift))
	    {
	        MaxAcceleration = 20f;
	    }

        if (Input.GetKey(LeftKey))
        {
            if (PreviousKey == RightKey)
            {
                // shoom
                acceleration = -MaxAcceleration*100f;
            }
            else
            {
                acceleration = -MaxAcceleration;
            }
           
            PreviousKey = LeftKey;
        }
        else if (Input.GetKey(RightKey))
        {

            if (PreviousKey == LeftKey)
            {
                // shoom 
                acceleration = MaxAcceleration*100f;
            }
            else
            {
                acceleration = MaxAcceleration;
            }


            PreviousKey = RightKey;
        }

        rigidBody.AddForce(Vector2.right * acceleration, ForceMode2D.Force);
	}
}

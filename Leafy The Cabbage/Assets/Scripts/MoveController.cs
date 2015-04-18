using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float MaxAcceleration = 4f;

    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode UpKey = KeyCode.E;
    public KeyCode DownKey = KeyCode.Q;
    public KeyCode ForwardKey = KeyCode.W;
    public KeyCode BackKey = KeyCode.S;

    private float Speed { get; set; }
    private float Acceleration { get; set; }

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var rigidBody = GetComponent<Rigidbody2D>();
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

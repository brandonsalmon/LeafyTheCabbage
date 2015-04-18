using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float MaxSpeed = 30f;
    public float MaxAcceleration = 20f;
    public float SpeedMultiplier = 2f;
    public float RotationSpeed = 10f;

    public KeyCode SpeedMultiplierKey = KeyCode.LeftShift;
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
        if (Input.GetKey(LeftKey))
        {
            Acceleration = -MaxAcceleration;
        }
        else if (Input.GetKey(RightKey))
        {
            Acceleration = MaxAcceleration;
        }
        else
        {
            Acceleration = Speed < 0f ? MaxAcceleration : Speed > 0f ? -MaxAcceleration : 0;
        }

        Rotate();

        var movement = Vector3.right;
        if (Input.GetKey(SpeedMultiplierKey))
        {
            movement *= SpeedMultiplier;
        }

        Speed += Acceleration * Time.deltaTime;
        Speed = Math.Min(Math.Max(Speed, -MaxSpeed), MaxSpeed);

        transform.position += movement * Speed * Time.deltaTime;
	}

    void Rotate()
    {
        transform.Rotate(Vector3.back * RotationSpeed * Speed / MaxSpeed);
    }
}

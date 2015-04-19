using LeafyTheCabbage.Domain.Character;
using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float MaxAcceleration = 10f;

    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode LeftShift = KeyCode.LeftShift;

    public KeyCode PreviousKey;

    public CharacterMovementState MovementState;
    public Orientation Orientation;

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var rigidBody = GetComponent<Rigidbody2D>();
	    var acceleration = 1f;

        if (rigidBody.velocity == Vector2.zero)
        {
            this.MovementState = CharacterMovementState.Idle;
        }else
        {
            this.MovementState = CharacterMovementState.Walking;
        }

        if (rigidBody.velocity.y != 0)
        {
            var jumpComp = this.GetComponent<JumpController>();
            if (jumpComp == null || !jumpComp.isJumping)
            {
                this.MovementState = CharacterMovementState.Bouncing;
            }
            if (jumpComp != null && jumpComp.isJumping)
            {
                this.MovementState = CharacterMovementState.Jumping;
            }
        }

	    if (Input.GetKey(LeftShift))
	    {
            this.MovementState = CharacterMovementState.Running;
	        MaxAcceleration = 20f;
	    }

        if (Input.GetKey(LeftKey))
        {
            this.Orientation = Orientation.Left;
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
            this.Orientation = Orientation.Right;
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
        else
        {
            acceleration = 0;
        }

        
        rigidBody.AddForce(Vector2.right * acceleration, ForceMode2D.Force);
	}
}

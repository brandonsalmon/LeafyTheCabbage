using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

    public float Speed = 4f;
    public float SpeedMultiplier = 8f;

    public KeyCode SpeedMultiplierKey = KeyCode.LeftShift;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode UpKey = KeyCode.E;
    public KeyCode DownKey = KeyCode.Q;
    public KeyCode ForwardKey = KeyCode.W;
    public KeyCode BackKey = KeyCode.S;

    public float rotationSpeed;
    //transform
    Transform myTrans;
    //object position
    Vector3 myPos;
    //object rotation
    Vector3 myRot;
    //object rotation 
    float angle;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{

        Vector3 movement = Vector3.zero;

        //if (Input.GetKey(LeftKey)) movement = Vector3.left;
        //if (Input.GetKey(RightKey)) movement = Vector3.right;
        //if (Input.GetKey(UpKey)) movement = Vector3.up;
        //if (Input.GetKey(DownKey)) movement = Vector3.down;
        //if (Input.GetKey(ForwardKey)) movement = Vector3.forward;
        //if (Input.GetKey(BackKey)) movement = Vector3.back;


        if (Input.GetKey(SpeedMultiplierKey))
        {
            movement *= SpeedMultiplier;
        }


        if (Input.GetKey(LeftKey))
        {
            RotateLeft();
            movement = Vector3.left;
        }

        if (Input.GetKey(RightKey))
        {
            RotateRight();
            movement = Vector3.right;
        }


        gameObject.transform.position
            += movement * Speed * Time.deltaTime;
	}


    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * 5);
    }

    void RotateRight()
    {
        transform.Rotate(Vector3.forward * -3);
    }
}

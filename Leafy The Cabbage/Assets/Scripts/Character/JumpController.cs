using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour {

    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode SpaceKey = KeyCode.Space;

    public float jumpHeight = 15;

    public bool isJumping;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody2D>();

        if (Input.GetKey(SpaceKey))
        {
            if (!isJumping)
            {
                rigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                isJumping = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Trigger")
        {
            isJumping = false;
        }
    }
}

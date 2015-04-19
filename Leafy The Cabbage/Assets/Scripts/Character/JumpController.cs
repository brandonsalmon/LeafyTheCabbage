using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;

public class JumpController : MonoBehaviour
{

    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode SpaceKey = KeyCode.Space;

    public float jumpHeight = 15;

    public bool isJumping;

    public AudioClip jumpSound;

    // Update is called once per frame
    void Update()
    {
        var rigidBody = GetComponent<Rigidbody2D>();

        if (Input.GetKey(SpaceKey) || CrossPlatformInputManager.GetButton("Jump"))
        {
            if (!isJumping)
            {
                this.GetComponent<AudioSource>().PlayOneShot(jumpSound);
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

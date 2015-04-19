using System;
using UnityEngine;
using System.Collections;

public class BunnyAttackController : MonoBehaviour
{
    private float _nextJumpTime;
    private bool _isJumping = false;

	// Use this for initialization
	void Start () {
        _nextJumpTime = UnityEngine.Random.Range(3, 7);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _nextJumpTime -= Time.deltaTime;
	    if (_nextJumpTime < 0 && !_isJumping)
	    {
	        var rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.AddForce(Vector2.up * 150, ForceMode2D.Impulse);
	        _isJumping = true;
	    }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        _isJumping = false;
        _nextJumpTime = UnityEngine.Random.Range(3, 7);
    }
}

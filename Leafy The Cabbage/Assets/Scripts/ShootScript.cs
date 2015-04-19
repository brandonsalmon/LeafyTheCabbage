using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour
{

    public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            // Create a new bullet at “transform.position”
            // Which is the current position of the game object
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
	}
}

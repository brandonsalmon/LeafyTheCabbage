using UnityEngine;
using System.Collections;

public class LevelCompleteController : MonoBehaviour
{
    public string Scene = "DiveGato";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            Debug.Log("Level Complete");
            Application.LoadLevel(Scene);
        }
    }
}

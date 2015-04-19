using UnityEngine;
using System.Collections;

public class RestartController : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var level = gameObject.GetComponentInParent<LevelController>();
            level.ReloadPlayerAtCheckpoint(other.gameObject);
        }
    }
}

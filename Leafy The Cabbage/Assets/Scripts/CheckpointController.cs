using UnityEngine;

public class CheckpointController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var level = gameObject.GetComponentInParent<LevelController>();
            level.SetLastCheckpoint(transform.position);
        }
    }
}

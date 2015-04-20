using UnityEngine;

public class CheckpointController : MonoBehaviour {

	public AudioClip checkpointReachedSound;

	private bool hasBeenHit = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			if (!hasBeenHit)
			{
				var audio = other.GetComponent<AudioSource>();
				audio.PlayOneShot(checkpointReachedSound);
				hasBeenHit = true;
			}
            var level = gameObject.GetComponentInParent<LevelController>();
            level.SetLastCheckpoint(transform.position);
        }
    }
}

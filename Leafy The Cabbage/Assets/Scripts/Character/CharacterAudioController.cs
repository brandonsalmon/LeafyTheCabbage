using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CharacterAudioController : MonoBehaviour {

    public AudioClip wallBumpMed;

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.tag == "CollidableWall") {
			GetComponent<AudioSource>().PlayOneShot(wallBumpMed, 0.7f);
        }
    }
}

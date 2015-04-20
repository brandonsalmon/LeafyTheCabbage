using UnityEngine;
using System.Collections;

public class EnemyTakeDamageController : MonoBehaviour
{

    public bool BulletInstaKill = false;

    public int BulletDamageAmount = -10;

    private HealthComponent health;
	private AudioSource audio;

    public AudioClip deathSound;

	// Use this for initialization
	void Start () {
        health = gameObject.GetComponent<HealthComponent>();
		audio = gameObject.GetComponent<AudioSource>();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            // Get rid of the bullet
            Destroy(col.gameObject);

            if (BulletInstaKill)
            {
                KillEnemy();
            }
            else
            {
                if (health != null)
                {
                    if (health.IsDead)
                    {
                        KillEnemy();
                    }
                    else
                    {
                        health.UpdateHealth(BulletDamageAmount);
                    }
                }
                else
                {
                    KillEnemy();
                }
            }
        }
    }

    void KillEnemy()
    {
        this.audio.PlayOneShot(deathSound);
        Destroy(gameObject);
    }
}

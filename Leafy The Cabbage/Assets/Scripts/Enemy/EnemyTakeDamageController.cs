using UnityEngine;
using System.Collections;

public class EnemyTakeDamageController : MonoBehaviour
{

    public bool BulletInstaKill = false;

    public int BulletDamageAmount = -10;

    private HealthComponent health;

    public AudioClip deathSound;

	// Use this for initialization
	void Start () {
        health = gameObject.GetComponent<HealthComponent>();
	}
	
	// Update is called once per frame
	void Update () {
	
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

        // TODO: damage from explosion
    }

    void KillEnemy()
    {
        this.GetComponent<AudioSource>().PlayOneShot(deathSound);

        Destroy(gameObject);
    }

}

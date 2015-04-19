using UnityEngine;
using System.Collections;

public class EnemyTakeDamageController : MonoBehaviour
{

    public bool BulletInstaKill = false;

    public int BulletDamageAmount = -10;

    private HealthComponent health;

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
                        Debug.Log("kill1");
                        KillEnemy();
                    }
                    else
                    {
                        Debug.Log("doin damage: " + health.CurrentHealth);
                        health.UpdateHealth(BulletDamageAmount);
                    }
                }
                else
                {
                    Debug.Log("kill2");
                    KillEnemy();
                }
            }
        }

        // TODO: damage from explosion
    }

    void KillEnemy()
    {
        // TODO: noise!
        Destroy(gameObject);
    }

}

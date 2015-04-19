using UnityEngine;
using System.Collections;

public class EnemyTakeDamageController : MonoBehaviour
{

    public bool BulletInstaKill = false;

    public int BulletDamageAmount = -10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (BulletInstaKill)
            {
                KillEnemy();
            }
            else
            {
                var healthComponent = gameObject.GetComponent<HealthComponent>();
                if (healthComponent)
                {
                    if (healthComponent.IsDead)
                    {
                        KillEnemy();
                    }
                    else
                    {
                        healthComponent.UpdateHealth(BulletDamageAmount);
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
        // TODO: noise!
        Destroy(gameObject);
    }

}

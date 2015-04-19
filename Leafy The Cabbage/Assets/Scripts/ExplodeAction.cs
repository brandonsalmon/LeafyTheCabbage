using System.Collections;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;

public class ExplodeAction : MonoBehaviour
{
    public float Power;
    public float Radius;
    public KeyCode ExplodeKey = KeyCode.E;
    public int Damage = -50;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(this.ExplodeKey)) //|| CrossPlatformInputManager.GetButton("Explode"))
        {
            StartCoroutine(this.Delayed());
        }
    }

    IEnumerator Delayed()
    {
        //yield return new WaitForSeconds(Random.value);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, this.Radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                AddExplosionForce(colliders[i].gameObject.GetComponent<Rigidbody2D>(), this.Power*100, gameObject.transform.position, this.Radius);
                var health = colliders[i].gameObject.GetComponent<HealthComponent>();
                Debug.Log("predamage");
                if (health != null)
                {
                    Debug.Log("damage");
                    health.UpdateHealth(Damage);
                }
            }
        }

        gameObject.GetComponent<HealthComponent>().Kill();

        yield return null;
    }

    public static void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        if (body != null)
        {
            var dir = (body.transform.position - expPosition);
            float calc = 1 - (dir.magnitude / expRadius);
            if (calc <= 0)
            {
                calc = 0;
            }

            body.AddForce(dir.normalized * expForce * calc);
        }
    }
}

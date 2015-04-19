using UnityEngine;
using System.Collections;

public class PainController : MonoBehaviour
{
    public int Damage = -10;

    public bool Pushback = true;

    private void OnCollide(Collider2D leafy)
    {
        if (leafy.tag == "Player")
        {
            leafy.GetComponent<HealthComponent>().UpdateHealth(Damage);

            if (Pushback)
            {
                var difference = leafy.transform.position - transform.position;
                leafy.GetComponent<Rigidbody2D>().AddForce(difference * 10, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnCollide(other);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollide(other.collider);
    }
}

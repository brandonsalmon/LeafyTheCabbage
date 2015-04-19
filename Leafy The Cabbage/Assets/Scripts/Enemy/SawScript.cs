using UnityEngine;

public class SawScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * 360);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var healthComponent = other.gameObject.GetComponent<HealthComponent>();

        if (healthComponent != null)
        {
            other.gameObject.GetComponent<HealthComponent>().Kill();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}

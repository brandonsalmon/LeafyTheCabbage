using UnityEngine;

public class SawScript : MonoBehaviour
{
    public Sprite WornSprite;

    public Sprite MegaKilledSprite;

    private bool hasFirstKill;

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
        if (other.tag == "Player")
        {
            if (hasFirstKill)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = MegaKilledSprite;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = WornSprite;
            }

            other.gameObject.GetComponent<HealthComponent>().Kill();

            hasFirstKill = true;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}

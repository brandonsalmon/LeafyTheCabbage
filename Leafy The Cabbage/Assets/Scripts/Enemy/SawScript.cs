using UnityEngine;

public class SawScript : MonoBehaviour
{
    public Sprite WornSprite;

    public Sprite MegaKilledSprite;

    private bool hasFirstKill;
    private float initialRotation;

    // Use this for initialization
    void Start()
    {
        this.initialRotation = Random.value * 360f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * (((Time.deltaTime * 360) + this.initialRotation) % 360f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (this.hasFirstKill)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = this.MegaKilledSprite;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = this.WornSprite;
            }

            other.gameObject.GetComponent<HealthComponent>().Kill();

            this.hasFirstKill = true;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}

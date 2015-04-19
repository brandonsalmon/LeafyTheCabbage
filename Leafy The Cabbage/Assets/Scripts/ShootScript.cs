using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;

public class ShootScript : MonoBehaviour
{

    public GameObject bullet;

    public bool BulletsEatHealth = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash) )//|| CrossPlatformInputManager.GetButton("Shoot"))
        {
            // Create a new bullet at “transform.position”
            // Which is the current position of the game object
            Instantiate(bullet, transform.position, Quaternion.identity);

            if (BulletsEatHealth)
            {
                var health = gameObject.GetComponent<HealthComponent>();
                health.UpdateHealth(-5);
            }
        }
    }
}

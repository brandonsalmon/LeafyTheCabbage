using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;

public class ShootScript : MonoBehaviour
{
	private AudioSource audio;

    public GameObject bullet;

    public bool BulletsEatHealth = true;

    public bool UseAI = false;
	public AudioClip bulletSound;
    private float _nextShootTime;

    // Use this for initialization
    void Start()
    {
        if (UseAI)
        {
            _nextShootTime = UnityEngine.Random.Range(1, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!UseAI && Input.GetKeyDown(KeyCode.Slash) )//|| CrossPlatformInputManager.GetButton("Shoot"))
        {
            // Create a new bullet at “transform.position”
            // Which is the current position of the game object
            Instantiate(bullet, transform.position, Quaternion.identity);
			this.audio.PlayOneShot(bulletSound, 0.7f);


            if (BulletsEatHealth)
            {
                var health = gameObject.GetComponent<HealthComponent>();
                health.UpdateHealth(-5);
            }
        }

        if (UseAI)
        {
            _nextShootTime -= Time.deltaTime;
            if (_nextShootTime < 0)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                _nextShootTime = UnityEngine.Random.Range(1, 3);
            }
        }
    }
}

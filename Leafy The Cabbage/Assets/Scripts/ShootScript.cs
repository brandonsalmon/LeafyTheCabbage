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
		this.audio = gameObject.GetComponent<AudioSource>();
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
            Instantiate(bullet, new Vector2(transform.position.x + 1, transform.position.y + 1), Quaternion.identity);
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
                //var yLocation = UnityEngine.Random.Range(transform.position.y + 50, transform.position.y +100);
                //var xLocation = UnityEngine.Random.Range(transform.position.x - 8, transform.position.x - 15);
                //Instantiate(bullet, new Vector2(yLocation, xLocation), Quaternion.identity);
                Instantiate(bullet, new Vector2(transform.position.x - 8, transform.position.y), Quaternion.identity);
                _nextShootTime = UnityEngine.Random.Range(1, 3);
            }
        }
    }
}

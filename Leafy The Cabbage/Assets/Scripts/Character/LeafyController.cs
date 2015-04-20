using LeafyTheCabbage.Domain.Character;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class LeafyController : MonoBehaviour
    {
        public CharacterLifeState LifeState = CharacterLifeState.Leafy_Idle;
        public CharacterMovementState MovementState = CharacterMovementState.Idle;

        public GameObject Leafy;
        public HealthComponent HealthComp;
        private MoveController moveController;
		private AudioSource audioSource;

        public Rect HealthBar;
        public int LazerDamage = -50;

		public AudioClip deathSound;

        // Use this for initialization
        void Start()
        {
            Leafy = gameObject;
            HealthComp = this.GetComponent<HealthComponent>();
            HealthBar = new Rect(50, Screen.height - 50, Screen.width, Screen.height);
            this.moveController = this.gameObject.GetComponent<MoveController>();
			this.audioSource = this.gameObject.GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            // Check if the character is dead
            if (HealthComp.IsDead && !HealthComp.Respawning)
            {
                HealthComp.Respawning = true;

                gameObject.GetComponent<ParticleSystem>().Play();
                this.LifeState = CharacterLifeState.Leafy_Dead;
				this.audioSource.PlayOneShot(deathSound);
                ResetLeafyAtCheckpoint();
            }

            if (!HealthComp.IsDead && HealthComp.Damaged)
            {
                this.LifeState = CharacterLifeState.Leafy_Tired;
            }

            if (!HealthComp.Damaged && !HealthComp.IsDead)
            {
                this.LifeState = CharacterLifeState.Leafy_Idle;
            }
            MovementState = moveController.MovementState;

            // Set appropriate sprites
            this.GetComponent<CharacterLifeSpriteController>().SetState(LifeState);
            this.GetComponent<MovementSpriteController>().SetState(MovementState);
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Lazer")
            {
                // Get rid of the lazer
                Destroy(col.gameObject);
                HealthComp.UpdateHealth(LazerDamage);
            }
        }

        public void ResetLeafyAtCheckpoint()
        {
            HealthComp.ResetHealth();
            Leafy.GetComponent<Renderer>().enabled = false;
            StartCoroutine(Delayed());
        }

        IEnumerator Delayed()
        {
            yield return new WaitForSeconds(Random.value);
            Leafy.GetComponentInParent<LevelController>().ReloadPlayerAtCheckpoint(Leafy);
            this.LifeState = CharacterLifeState.Leafy_Idle;
        }

        // HEALTH BAR:
        void OnGUI()
        {
            GUI.Label(HealthBar, "Health: " + HealthComp.CurrentHealth);
        }
    }
}

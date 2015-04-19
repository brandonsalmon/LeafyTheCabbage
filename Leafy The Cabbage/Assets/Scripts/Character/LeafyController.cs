using LeafyTheCabbage.Domain.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class LeafyController : MonoBehaviour
    {
        public CharacterLifeState LifeState = CharacterLifeState.Alive;
        public CharacterMovementState MovementState = CharacterMovementState.Idle;
        

        public GameObject Leafy;
        public HealthComponent HealthComp;
        private MoveController moveController;

        public Rect HealthBar;

        // Use this for initialization
        void Start()
        {
            Leafy = gameObject;
            HealthComp = this.GetComponent<HealthComponent>();
            HealthBar = new Rect(50, Screen.height - 50, Screen.width, Screen.height);
            this.moveController = this.gameObject.GetComponent<MoveController>();
        }

        // Update is called once per frame
        void Update()
        {
            // Check if the character is dead
            if (HealthComp.IsDead)
            {
                this.LifeState = CharacterLifeState.Dead;
                ResetLeafyAtCheckpoint();
            }
            MovementState = moveController.MovementState;

            // Set appropriate sprites
            //this.GetComponent<CharacterLifeSpriteController>().SetState(LifeState);
            this.GetComponent<MovementSpriteController>().SetState(MovementState);
        }

        public void ResetLeafyAtCheckpoint()
        {
            Leafy.GetComponentInParent<LevelController>().ReloadPlayerAtCheckpoint(Leafy);
            HealthComp.ResetHealth();
        }

        // HEALTH BAR:
        void OnGUI()
        {
            GUI.Label(HealthBar, "Health: " + HealthComp.CurrentHealth);
        }
    }
}

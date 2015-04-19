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

        // Use this for initialization
        void Start()
        {
            Leafy = gameObject;
            HealthComp = this.GetComponent<HealthComponent>();
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
            MovementState = CharacterMovementState.Jumping;
            // Set appropriate sprites
            //this.GetComponent<CharacterLifeSpriteController>().SetState(LifeState);
            this.GetComponent<MovementSpriteController>().SetState(MovementState);
        }

        public void ResetLeafyAtCheckpoint()
        {
            Leafy.GetComponentInParent<LevelController>().ReloadPlayerAtCheckpoint(Leafy);
            HealthComp.ResetHealth();
        }
    }
}

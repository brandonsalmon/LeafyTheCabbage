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

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var healthComp = this.GetComponent<HealthComponent>();
            // Check if the character is dead
            if (healthComp.IsDead)
            {
                this.LifeState = CharacterLifeState.Dead;
            }
            MovementState = CharacterMovementState.Jumping;
            // Set appropriate sprites
            //this.GetComponent<CharacterLifeSpriteController>().SetState(LifeState);
            this.GetComponent<MovementSpriteController>().SetState(MovementState);
        }
    }
}

using LeafyTheCabbage.Domain.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CharacterController : MonoBehaviour
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
            // Check if the character is dead
            if(this.GetComponent<HealthComponent>().IsDead)
            {
                this.LifeState = CharacterLifeState.Dead;
            }

            this.GetComponent<MovementAnimationController>().SetState(MovementState);
        }
    }
}

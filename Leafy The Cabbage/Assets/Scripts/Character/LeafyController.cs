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
        private HealthComponent healthComp;
        private MoveController moveController;

        // Use this for initialization
        void Start()
        {
            this.healthComp = this.gameObject.GetComponent<HealthComponent>();
            this.moveController = this.gameObject.GetComponent<MoveController>();
        }

        // Update is called once per frame
        void Update()
        {
            //if (healthComp == null)
            //{
            //    healthComp = this.gameObject.GetComponent<HealthComponent>();
            //}
            //if (moveController == null)
            //{
            //    moveController = this.gameObject.GetComponent<MoveController>();
            //}
            // Check if the character is dead
            if (healthComp.IsDead)
            {
                this.LifeState = CharacterLifeState.Dead;
            }
            MovementState = moveController.MovementState;
            Debug.Log("Current moveController state: " + moveController.MovementState.ToString());
            // Set appropriate sprites
            //this.GetComponent<CharacterLifeSpriteController>().SetState(LifeState);
            this.GetComponent<MovementSpriteController>().SetState(MovementState);
        }
    }
}

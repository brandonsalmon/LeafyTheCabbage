using LeafyTheCabbage.Domain.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class MovementAnimationController : MonoBehaviour
    {
        public Dictionary<CharacterMovementState, Sprite> AnimationLibrary;

        private CharacterMovementState currentState;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetState(CharacterMovementState state)
        {
            if(AnimationLibrary.ContainsKey(state))
            {
                currentState = state;
                this.GetComponent<SpriteRenderer>().sprite = AnimationLibrary[state];
            }
        }
    }
}

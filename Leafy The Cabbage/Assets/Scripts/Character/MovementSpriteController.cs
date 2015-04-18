using LeafyTheCabbage.Domain.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class MovementSpriteController : MonoBehaviour
    {
        public Dictionary<CharacterMovementState, Sprite> SpriteLibrary = new Dictionary<CharacterMovementState,Sprite>();

        private CharacterMovementState currentState;

        // Use this for initialization
        void Start()
        {
            foreach (CharacterMovementState state in Enum.GetValues(typeof(CharacterMovementState)))
            {
                try
                {
                    
                    var sprite = Resources.Load<Sprite>(state.ToString() + ".png"); 
                    SpriteLibrary.Add(state, sprite);
                    Debug.Log("Loaded sprite for state: " + state.ToString());  
                }
                catch
                {

                }
                
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetState(CharacterMovementState state)
        {
            if (SpriteLibrary.ContainsKey(state))
            {
                Debug.Log("Changing to sprite for state: " + state.ToString());  
                currentState = state;
                //this.GetComponentInParent<SpriteRenderer>().sprite = SpriteLibrary[state];
            }
        }
    }
}

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
        public List<Sprite> Sprites;
        public Dictionary<CharacterMovementState, Sprite> SpriteLibrary;

        private CharacterMovementState currentState;
        private SpriteRenderer renderer;

        // Use this for initialization
        void Start()
        {
            renderer = this.gameObject.GetComponent<SpriteRenderer>();
            SpriteLibrary = new Dictionary<CharacterMovementState,Sprite>();
            foreach (CharacterMovementState state in Enum.GetValues(typeof(CharacterMovementState)))
            {
                try
                {
                    var sprite = Sprites.Where(x => x.name == state.ToString()).Single();
                    if(sprite != null)
                    {
                        Debug.Log("Added sprite for state: " + state.ToString());
                        SpriteLibrary.Add(state, sprite);
                    }
                }
                catch (Exception e)
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
                currentState = state;
                renderer.sprite = SpriteLibrary[state];
                this.GetComponentInParent<SpriteRenderer>().sprite = SpriteLibrary[state];
            }
        }
    }
}

using LeafyTheCabbage.Domain.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CharacterLifeSpriteController : MonoBehaviour
    {
        public List<Sprite> Sprites;
        public Dictionary<CharacterLifeState, Sprite> SpriteLibrary;

        private CharacterLifeState currentState;
        private SpriteRenderer renderer;

        // Use this for initialization
        void Start()
        {
            renderer = this.gameObject.GetComponent<SpriteRenderer>();
            SpriteLibrary = new Dictionary<CharacterLifeState, Sprite>();
            foreach (CharacterLifeState state in Enum.GetValues(typeof(CharacterLifeState)))
            {
                try
                {
                    var sprite = Sprites.Where(x => x.name == state.ToString()).Single();
                    if (sprite != null)
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

        public void SetState(CharacterLifeState state)
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

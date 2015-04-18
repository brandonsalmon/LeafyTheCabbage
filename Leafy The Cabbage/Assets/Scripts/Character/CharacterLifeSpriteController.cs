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
        public Dictionary<CharacterLifeState, Sprite> SpriteLibrary = new Dictionary<CharacterLifeState,Sprite>();

        private CharacterLifeState currentState;

        public void SetState(CharacterLifeState state)
        {
            if (SpriteLibrary.ContainsKey(state))
            {
                currentState = state;
                this.GetComponent<SpriteRenderer>().sprite = SpriteLibrary[state];
            }
        }
    }
}

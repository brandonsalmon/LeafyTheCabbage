using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeafyTheCabbage.Domain.Character
{
    public enum CharacterMovementState
    {
        Idle,
        Left,
        Right,
        JumpAscend,
        JumpDescend,
        Bouncing
    }
}

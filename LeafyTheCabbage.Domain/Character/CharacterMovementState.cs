using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

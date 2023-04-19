using System;
using UnityEngine;

namespace AgarMirror.InputSystem.Interfaces
{
    public interface IInputListener
    {
       bool TryMoveWithMouse (out Vector2 direction);

        bool TryMoveWithArrows(out Vector2 direction);

        void Enable();

        void Disable();
    }
}

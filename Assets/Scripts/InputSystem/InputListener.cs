using AgarMirror.InputSystem.Interfaces;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AgarMirror.InputSystem
{
    public class InputListener : IInputListener
    {
        private PlayerInput _playerInput;

        public event Action OnMousePerformed;

        public bool TryMoveWithArrows (out Vector2 direction)
        {
            direction = _playerInput.Player.MoveArrows.ReadValue<Vector2>();

            return direction != Vector2.zero;
        }

        public bool TryMoveWithMouse(out Vector2 direction)
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;

           
            return _playerInput.Player.MoveMouse.phase == InputActionPhase.Started;
        }

        public InputListener ()
        {
            _playerInput = new PlayerInput();

            
        }

        public void Enable () 
            => _playerInput.Enable();

        public void Disable () 
            => _playerInput.Disable();

        
    }
}

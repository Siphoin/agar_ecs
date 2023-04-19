using UnityEngine;
using System;
using AgarMirror.InputSystem.Interfaces;
using AgarMirror.InputSystem;

namespace AgarMirror.Control
{
    [RequireComponent(typeof(PlayerMono))]
    [RequireComponent(typeof(PlayerMono))]
    public class PlayerControl : MonoBehaviour
    {
        private PlayerMono _playerMono;

        private Rigidbody2D _body;

        private IInputListener _inputListener;

        private void Start()
        {
            if (!TryGetComponent(out  _playerMono))
            {
                throw new NullReferenceException("player control must have component PlayerMono");
            }

            if (!_playerMono.isLocalPlayer)
            {
                Destroy(this);
            }

            if (!TryGetComponent(out _body))
            {
                throw new NullReferenceException("player control must have component RigidBody2D");
            }

            _inputListener = Startup.Input;

            

           

            OnEnable();
        }

        private void FixedUpdate()
        {
            MoveWithDirection();

            MoveWithMouse();
        }

        private void OnEnable() 
            => _inputListener?.Enable();

        private void OnDisable()
           => _inputListener?.Disable();




        public void MoveWithDirection ()
        {
            if (_inputListener.TryMoveWithArrows(out Vector2 direction))
            {
                Move(direction);
            }
        }

        private void MoveWithMouse ()
        {
            if (_inputListener.TryMoveWithMouse(transform, out Vector2 direction))
            {
                Move(direction);
            }
        }

        private void Move (Vector2 direction)
            => _body.MovePosition(_body.position + direction * 4 * Time.fixedDeltaTime);
    }
}
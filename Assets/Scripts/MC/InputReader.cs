using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TC
{
    [CreateAssetMenu(fileName = "New Input Reader", menuName = "Player Input")]
    public class InputReader : ScriptableObject, MCInput.IGameplayActions
    {
        public Action<Vector2> MoveEvent;
        public Action JumpEvent;
        public Action InteractEvent;


        MCInput _MCInput;
        void OnEnable()
        {
            if (_MCInput == null)
            {
                _MCInput = new MCInput();
                _MCInput.Gameplay.SetCallbacks(this);
            }

            _MCInput.Gameplay.Enable();
        }

        void OnDisable()
        {
            if (_MCInput != null) _MCInput.Gameplay.Disable();
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                JumpEvent?.Invoke();
            }
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                InteractEvent?.Invoke();
            }
        }
    }
}

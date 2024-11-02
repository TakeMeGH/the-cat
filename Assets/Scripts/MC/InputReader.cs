using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TC
{
    [CreateAssetMenu(fileName = "New Input Reader", menuName = "Player Input")]
    public class InputReader : ScriptableObject, MCInput.IGameplayActions, MCInput.IUIActions
    {
        public Action<Vector2> MoveEvent;
        public Action JumpEvent;
        public Action InteractEvent;
        public Action OpenPauseEvent;
        public Action ClosePauseEvent;
        public Action StartGameEvent;




        MCInput _MCInput;
        void OnEnable()
        {
            if (_MCInput == null)
            {
                _MCInput = new MCInput();
                _MCInput.Gameplay.SetCallbacks(this);
                _MCInput.UI.SetCallbacks(this);
            }

            EnableGameplayInput();
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

        public void OnOpenPauseMenu(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                OpenPauseEvent?.Invoke();
            }
        }

        public void OnClosePauseMenu(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ClosePauseEvent?.Invoke();
            }
        }

        public void OnStartGame(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                StartGameEvent?.Invoke();
            }

        }


        public void EnableGameplayInput()
        {
            _MCInput.Gameplay.Enable();
            _MCInput.UI.Disable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void EnableUIInput()
        {
            _MCInput.Gameplay.Disable();
            _MCInput.UI.Enable();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

    }
}

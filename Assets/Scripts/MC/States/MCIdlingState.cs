using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class MCIdlingState : IState
    {
        protected MCController _MCController;
        const string ANIMATION_NAME = "MC_Idle";
        float _playSoundTime = 15f;
        float _currentTime;

        public MCIdlingState(MCController _MCController)
        {
            this._MCController = _MCController;
        }

        public void Enter()
        {
            _currentTime = _playSoundTime;
            _MCController.Animator.Play(ANIMATION_NAME);
            _MCController.InputReader.JumpEvent += OnJump;
            _MCController.InputReader.InteractEvent += OnInteract;
        }


        public void Exit()
        {
            _MCController.InputReader.JumpEvent -= OnJump;
            _MCController.InputReader.InteractEvent -= OnInteract;

        }

        public void PhysicsUpdate()
        {
            if (_MCController.MoveDirection != Vector2.zero)
            {
                _MCController.SwitchState(_MCController.MCWalkingState);
                return;
            }

            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                _currentTime = _playSoundTime;
                AudioManager.Instance.PlaySFX(GeneralSFX.IdleMeow);
            }

            _MCController.Rigidbody.velocity = new Vector3(0, _MCController.Rigidbody.velocity.y, 0);
            CheckFalling();
        }

        public void Update()
        {
        }

        void OnJump()
        {
            _MCController.SwitchState(_MCController.MCJumpingState);
        }

        void CheckFalling()
        {
            if (_MCController.Rigidbody.velocity.y < _MCController.FallingThreshold)
            {
                _MCController.SwitchState(_MCController.MCFallingState);
            }
        }

        void OnInteract()
        {
            if (_MCController.InteractionManager.IsCanInteract())
            {
                _MCController.SwitchState(_MCController.MCInteractingState);
            }
        }


    }
}

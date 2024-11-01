using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class MCIdlingState : IState
    {
        protected MCController _MCController;
        const string ANIMATION_NAME = "MC_Idle";

        public MCIdlingState(MCController _MCController)
        {
            this._MCController = _MCController;
        }

        public void Enter()
        {
            _MCController.Animator.Play(ANIMATION_NAME);
            _MCController.InputReader.JumpEvent += OnJump;
        }

        public void Exit()
        {
            _MCController.InputReader.JumpEvent -= OnJump;
        }

        public void PhysicsUpdate()
        {
            if (_MCController.MoveDirection != Vector2.zero)
            {
                _MCController.SwitchState(_MCController.MCWalkingState);
            }
        }

        public void Update()
        {
        }

        void OnJump()
        {
            _MCController.SwitchState(_MCController.MCJumpingState);
        }
    }
}

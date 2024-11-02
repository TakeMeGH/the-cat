using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class MCJumpingState : IState
    {
        protected MCController _MCController;
        const string ANIMATION_NAME = "MC_Jump";
        public MCJumpingState(MCController _MCController)
        {
            this._MCController = _MCController;
        }

        public void Enter()
        {
            _MCController.Animator.Play(ANIMATION_NAME);
            _MCController.InputReader.JumpEvent += OnJump;

            _MCController.Rigidbody.velocity = Vector2.zero;
            Jump();
        }

        public void Exit()
        {
            _MCController.InputReader.JumpEvent -= OnJump;
        }

        public void PhysicsUpdate()
        {
        }

        public void Update()
        {
            if (IsMovingUp(-0.01f))
            {
                return;
            }

            _MCController.SwitchState(_MCController.MCFallingState);
        }

        public void Jump()
        {
            _MCController.Rigidbody.velocity = Vector3.zero;
            _MCController.Rigidbody.AddForce(new Vector3(_MCController.MoveDirection.x, _MCController.JumpForce, _MCController.MoveDirection.y), ForceMode.VelocityChange);
            _MCController.CurrentJumpAmount++;
        }

        Vector3 GetPlayerVerticalVelocity()
        {
            return new Vector3(0f, _MCController.Rigidbody.velocity.y, 0f);
        }


        bool IsMovingUp(float minimumVelocity = 0.1f)
        {
            return GetPlayerVerticalVelocity().y > minimumVelocity;
        }

        void OnJump()
        {
            if (_MCController.CurrentJumpAmount < _MCController.MaxJumpAmmount)
            {
                Jump();
            }
        }

    }
}

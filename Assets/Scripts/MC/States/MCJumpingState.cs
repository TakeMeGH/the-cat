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
            Jump();
        }

        public void Exit()
        {
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
            _MCController.Rigidbody.AddForce(new Vector3(0, _MCController.JumpForce, 0), ForceMode.VelocityChange);
        }

        Vector3 GetPlayerVerticalVelocity()
        {
            return new Vector3(0f, _MCController.Rigidbody.velocity.y, 0f);
        }


        bool IsMovingUp(float minimumVelocity = 0.1f)
        {
            return GetPlayerVerticalVelocity().y > minimumVelocity;
        }


    }
}

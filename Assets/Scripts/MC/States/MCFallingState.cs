using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class MCFallingState : IState
    {
        protected MCController _MCController;
        const string ANIMATION_NAME = "MC_Fall";

        float _jumpButtonTime = -1;

        public MCFallingState(MCController _MCController)
        {
            this._MCController = _MCController;
        }

        public void Enter()
        {
            _MCController.Animator.Play(ANIMATION_NAME);
            _MCController.GroundDetector.OnGroundDetected += OnGroundDetected;
            _MCController.InputReader.JumpEvent += OnJump;

        }

        public void Exit()
        {
            _MCController.GroundDetector.OnGroundDetected -= OnGroundDetected;
            _MCController.InputReader.JumpEvent -= OnJump;
            _jumpButtonTime = -1;

        }

        public void PhysicsUpdate()
        {
            _MCController.Rigidbody.AddForce(Vector2.up * Physics.gravity.y *
            (_MCController.FallMultiplier - 1), ForceMode.Acceleration);

            if (_MCController.Rigidbody.velocity.y < _MCController.MaxFallSpeed)
            {
                _MCController.Rigidbody.velocity = new Vector3(
                _MCController.Rigidbody.velocity.x,
                _MCController.MaxFallSpeed,
                _MCController.Rigidbody.velocity.z);
            }

        }

        public void Update()
        {
        }

        void OnGroundDetected()
        {
            _MCController.Rigidbody.velocity = new Vector3(_MCController.Rigidbody.velocity.x,
            0, _MCController.Rigidbody.velocity.z);
            
            if (_jumpButtonTime + _MCController.JumpBufferTime >= Time.time)
            {
                _MCController.CurrentJumpAmount = 0;
                _MCController.SwitchState(_MCController.MCJumpingState);
                return;
            }

            _MCController.CurrentJumpAmount = 0;
            _MCController.SwitchState(_MCController.MCIdlingState);
        }

        void OnJump()
        {
            if (_MCController.CurrentJumpAmount < _MCController.MaxJumpAmmount)
            {
                _MCController.SwitchState(_MCController.MCJumpingState);
            }
            else
            {
                _jumpButtonTime = Time.time;
            }

        }

    }
}

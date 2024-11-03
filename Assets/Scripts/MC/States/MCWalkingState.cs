using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TC
{
    public class MCWalkingState : IState
    {
        protected MCController _MCController;
        const string RIGHT_ANIMATION_NAME = "MC_WalkRight";
        const string IDLE_ANIMATION_NAME = "MC_Idle";

        const string UP_ANIMATION_NAME = "MC_WalkUp";
        const string DOWN_ANIMATION_NAME = "MC_WalkDown";
        float _lastMove;
        float _delayTime;
        string _lastAnimation = "";
        public MCWalkingState(MCController _MCController)
        {
            this._MCController = _MCController;
        }

        public void Enter()
        {
            _MCController.InputReader.JumpEvent += OnJump;
            _MCController.InputReader.InteractEvent += OnInteract;

            if (_MCController.IsUsingDelay)
            {
                if (Time.time - _lastMove <= _MCController.WalkDelayIntervalCompensation)
                {
                    _delayTime = 0;
                }
                else
                {
                    _delayTime = _MCController.WalkDelay;
                }
                _lastAnimation = IDLE_ANIMATION_NAME;
                _MCController.Animator.Play(IDLE_ANIMATION_NAME);
            }
            else
            {
                HandleAnimation();
            }

        }

        public void Exit()
        {
            _lastAnimation = "";
            _MCController.InputReader.JumpEvent -= OnJump;
            _MCController.InputReader.InteractEvent -= OnInteract;
            _lastMove = Time.time;

        }

        public void PhysicsUpdate()
        {
            _delayTime -= Time.deltaTime;
            if (_MCController.IsUsingDelay && _delayTime > 0) return;
            HandleAnimation();
            HandleMove();
            CheckFalling();
        }

        public void Update()
        {
        }

        void HandleAnimation()
        {
            if (_MCController.MoveDirection.x > 0f || (_MCController.MoveDirection.x == 0 && _MCController.MoveDirection.y != 0))
            {
                _MCController.SpriteRenderer.flipX = false;
                if (_lastAnimation != RIGHT_ANIMATION_NAME)
                {
                    _lastAnimation = RIGHT_ANIMATION_NAME;
                    _MCController.Animator.Play(RIGHT_ANIMATION_NAME);
                }
            }
            else if (_MCController.MoveDirection.x < 0f)
            {
                _MCController.SpriteRenderer.flipX = true;
                if (_lastAnimation != RIGHT_ANIMATION_NAME)
                {
                    _lastAnimation = RIGHT_ANIMATION_NAME;
                    _MCController.Animator.Play(RIGHT_ANIMATION_NAME);
                }
            }
            // else if (_MCController.MoveDirection.y > 0)
            // {
            //     _MCController.SpriteRenderer.flipX = false;
            //     if (_lastAnimation != UP_ANIMATION_NAME)
            //     {
            //         _lastAnimation = UP_ANIMATION_NAME;
            //         _MCController.Animator.Play(UP_ANIMATION_NAME);
            //     }
            // }
            // else if (_MCController.MoveDirection.y < 0)
            // {
            //     _MCController.SpriteRenderer.flipX = false;
            //     if (_lastAnimation != DOWN_ANIMATION_NAME)
            //     {
            //         _lastAnimation = DOWN_ANIMATION_NAME;
            //         _MCController.Animator.Play(DOWN_ANIMATION_NAME);
            //     }
            // }
            else
            {
                _MCController.SwitchState(_MCController.MCIdlingState);
            }

        }

        void HandleMove()
        {
            float x = _MCController.MoveDirection.x;
            float z = _MCController.MoveDirection.y;
            Vector3 moveDir = new Vector3(x, 0, z);

            Vector3 currentPlayerHorizontalVelocity = GetPlayerHorizontalVelocity();

            _MCController.Rigidbody.AddForce(
                moveDir * _MCController.Speed -
                currentPlayerHorizontalVelocity,
                ForceMode.VelocityChange);

        }

        protected Vector3 GetPlayerHorizontalVelocity()
        {
            Vector3 playerHorizontalVelocity = _MCController.Rigidbody.velocity;

            playerHorizontalVelocity.y = 0f;

            return playerHorizontalVelocity;
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

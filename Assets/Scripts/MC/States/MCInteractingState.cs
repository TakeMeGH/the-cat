using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class MCInteractingState : IState
    {
        protected MCController _MCController;
        const string ANIMATION_NAME = "MC_Interact";

        bool _allowMove = false;

        public MCInteractingState(MCController _MCController)
        {
            this._MCController = _MCController;
        }

        public void Enter()
        {
            _MCController.Animator.Play(ANIMATION_NAME);
            _MCController.Rigidbody.velocity = new Vector3(0, _MCController.Rigidbody.velocity.y, 0);
            _MCController.AnimationEventTrigger.TriggerOnMovementStateAnimationExitEvent.AddListener(OnAnimationEnd);
            _MCController.AnimationEventTrigger.TriggerOnMovementStateAnimationTransitionEvent.AddListener(InteractObject);
        }

        public void Exit()
        {
            _MCController.AnimationEventTrigger.TriggerOnMovementStateAnimationExitEvent.RemoveListener(OnAnimationEnd);
            _MCController.AnimationEventTrigger.TriggerOnMovementStateAnimationTransitionEvent.RemoveListener(InteractObject);
            _allowMove = false;
        }

        public void PhysicsUpdate()
        {
            if (_allowMove && _MCController.MoveDirection != Vector2.zero)
            {
                _MCController.SwitchState(_MCController.MCWalkingState);
                return;
            }
        }

        public void Update()
        {
        }

        void OnAnimationEnd()
        {
            _MCController.SwitchState(_MCController.MCIdlingState);
        }

        void InteractObject()
        {
            _MCController.InteractionManager.OnInteractionButtonPress();
            _allowMove = true;
        }

    }
}

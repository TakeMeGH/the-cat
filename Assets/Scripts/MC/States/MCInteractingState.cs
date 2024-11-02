using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class MCInteractingState : IState
    {
        protected MCController _MCController;
        const string ANIMATION_NAME = "MC_Interact";

        float _jumpButtonTime = -1;

        public MCInteractingState(MCController _MCController)
        {
            this._MCController = _MCController;
        }

        public void Enter()
        {
            _MCController.Animator.Play(ANIMATION_NAME);
            _MCController.AnimationEventTrigger.TriggerOnMovementStateAnimationExitEvent.AddListener(OnAnimationEnd);
            _MCController.AnimationEventTrigger.TriggerOnMovementStateAnimationTransitionEvent.AddListener(InteractObject);
        }

        public void Exit()
        {
            _MCController.AnimationEventTrigger.TriggerOnMovementStateAnimationExitEvent.RemoveListener(OnAnimationEnd);
            _MCController.AnimationEventTrigger.TriggerOnMovementStateAnimationTransitionEvent.RemoveListener(InteractObject);

        }

        public void PhysicsUpdate()
        {
            if (_MCController.MoveDirection != Vector2.zero)
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
        }

    }
}

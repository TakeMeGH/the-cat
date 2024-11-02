using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TC
{
    public class AnimationEventTrigger : MonoBehaviour
    {
        public UnityEvent TriggerOnMovementStateAnimationEnterEvent;
        public UnityEvent TriggerOnMovementStateAnimationExitEvent;
        public UnityEvent TriggerOnMovementStateAnimationTransitionEvent;
        public void EnterEvent()
        {
            TriggerOnMovementStateAnimationEnterEvent?.Invoke();
        }

        public void ExitEvent()
        {
            TriggerOnMovementStateAnimationExitEvent?.Invoke();
        }

        public void TransitionEvent()
        {
            TriggerOnMovementStateAnimationTransitionEvent?.Invoke();
        }

    }
}

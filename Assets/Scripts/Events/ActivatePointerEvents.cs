using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TC
{

    [CreateAssetMenu(fileName = "New Activate Pointer Event", menuName = "Events/Activate Pointer Event")]
    public class ActivatePointerEvents : ScriptableObject
    {
        public UnityAction<Transform, float> EventAction;

        public void RaiseEvent(Transform target, float duration)
        {
            EventAction?.Invoke(target, duration);
        }
    }
}

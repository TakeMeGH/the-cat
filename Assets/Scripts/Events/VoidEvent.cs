using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TC
{

    [CreateAssetMenu(fileName = "New Void Event", menuName = "Events/Void Event")]
    public class VoidEvent : ScriptableObject
    {
        public UnityAction EventAction;

        public void RaiseEvent()
        {
            EventAction?.Invoke();
        }
    }
}

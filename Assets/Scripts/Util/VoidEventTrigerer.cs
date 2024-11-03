using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class VoidEventTrigerer : MonoBehaviour
    {
        [SerializeField] VoidEvent _event;
        private void OnTriggerEnter(Collider other)
        {
            _event.RaiseEvent();
        }
    }
}

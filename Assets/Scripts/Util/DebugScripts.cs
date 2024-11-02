using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class DebugScripts : MonoBehaviour
    {
        public Transform PointerLocation;
        public float PointerDuration;
        public ActivatePointerEvents ActivatePointerEvents;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                ActivatePointerEvents.RaiseEvent(PointerLocation, PointerDuration);
            }
        }
    }
}

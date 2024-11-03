using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class DebugScripts : MonoBehaviour
    {
        [Header("Pointer")]
        public Transform PointerLocation;
        public float PointerDuration;
        public ActivatePointerEvents ActivatePointerEvents;

        [Header("Bubble")]
        public float BubbleDuration;
        public Sprite BubbleSprite;
        public BubbleIconEvent BubbleIconEvent;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                ActivatePointerEvents.RaiseEvent(PointerLocation, PointerDuration);
            }

            if (Input.GetKeyDown(KeyCode.F2))
            {
                BubbleIconEvent.RaiseEvent(BubbleSprite, BubbleDuration);
            }

        }
    }
}

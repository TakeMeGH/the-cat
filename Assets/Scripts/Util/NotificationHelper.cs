using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class NotificationHelper : MonoBehaviour
    {
        [Header("Pointer")]
        [SerializeField] Transform _towelLocation;
        [SerializeField] Transform _waterLocation;
        [SerializeField] float _pointerDuration;
        [SerializeField] ActivatePointerEvents _activatePointerEvents;

        [Header("Bubble")]
        [SerializeField] Sprite _towelSprite;
        [SerializeField] Sprite _waterSprite;
        [SerializeField] float _bubbleDuration;
        [SerializeField] BubbleIconEvent _bubbleIconEvent;
        void OnCollisionEnter(Collision other)
        {
            if (!DataManager.Instance.IsTowelExist())
            {
                _activatePointerEvents.RaiseEvent(_towelLocation, _pointerDuration);
                _bubbleIconEvent.RaiseEvent(_towelSprite, _bubbleDuration);

            }
            else if (!DataManager.Instance.IsWaterExist())
            {
                _activatePointerEvents.RaiseEvent(_waterLocation, _pointerDuration);
                _bubbleIconEvent.RaiseEvent(_waterSprite, _bubbleDuration);

            }
        }
    }
}

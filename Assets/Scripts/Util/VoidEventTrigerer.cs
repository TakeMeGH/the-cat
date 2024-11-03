using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class VoidEventTrigerer : MonoBehaviour
    {
        [SerializeField] VoidEvent _event;
        public bool IsOnFinishGame = false;

        private void OnTriggerEnter(Collider other)
        {
            if (IsOnFinishGame)
            {
                if (DataManager.Instance.IsAlarmPressed())
                {
                    _event.RaiseEvent();
                }
            }
            else
            {
                _event.RaiseEvent();

            }
        }
    }
}

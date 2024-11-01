using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class GroundDetector : MonoBehaviour
    {
        public Action OnGroundDetected;

        private void OnCollisionEnter(Collision other)
        {
            OnGroundDetected?.Invoke();
        }
    }
}

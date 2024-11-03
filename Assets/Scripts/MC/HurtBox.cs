using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class HurtBox : MonoBehaviour
    {
        [SerializeField] HealthController _healthController;
        void OnTriggerEnter(Collider other)
        {
            _healthController.ReduceHealth();
        }
    }
}

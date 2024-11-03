using System;
using UnityEngine;
using UnityEngine.Events;

namespace TC
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] int _maxHealth;
        [SerializeField] float _invulnerableTime;
        public UnityEvent<int> OnDamaged;
        float _hitTime;
        int _currentHealth;
        void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void ReduceHealth()
        {
            if (_hitTime + _invulnerableTime >= Time.time)
            {
                return;
            }
            _hitTime = Time.time;
            _currentHealth--;
            OnDamaged?.Invoke(_currentHealth);
            // if (_currentHealth > 0)
            // {
            //     OnRespawnEvent.RaiseEvent();
            // }
            // else
            // {
            //     OnGameOverEvent.RaiseEvent();
            // }
        }
    }
}

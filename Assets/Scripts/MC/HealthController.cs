using System;
using UnityEngine;

namespace TC
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] int _maxHealth;
        [SerializeField] VoidEvent OnRespawnEvent;
        [SerializeField] VoidEvent OnGameOverEvent;
        [SerializeField] float _invulnerableTime;
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
            if (_currentHealth > 0)
            {
                OnRespawnEvent.RaiseEvent();
            }
            else
            {
                OnGameOverEvent.RaiseEvent();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class PostionPointer : MonoBehaviour
    {

        [SerializeField] ActivatePointerEvents _activatePointerEvents;
        MeshRenderer _mesh;
        Transform _target;
        Vector3 _rotationOffset;
        float _duration = -1;
        float _currentTime;

        void OnEnable()
        {
            _activatePointerEvents.EventAction += ActivatePointer;
        }

        void OnDisable()
        {
            _activatePointerEvents.EventAction -= ActivatePointer;
        }

        void Start()
        {
            _mesh = GetComponent<MeshRenderer>();
        }
        void Update()
        {
            if (_target != null && _currentTime + _duration >= Time.time)
            {
                if (_mesh.enabled == false) _mesh.enabled = true;

                transform.LookAt(_target);

                transform.rotation *= Quaternion.Euler(_rotationOffset);
            }
            else
            {
                if (_mesh.enabled == true) _mesh.enabled = false;
            }

        }
        void ActivatePointer(Transform target, float duration)
        {
            _target = target;
            _currentTime = Time.time;
            _duration = duration;

        }

    }
}

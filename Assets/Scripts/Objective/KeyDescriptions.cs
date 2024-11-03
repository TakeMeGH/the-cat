using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class KeyDescriptions : MonoBehaviour
    {
        [SerializeField] public string ID;
        public void StoreKey()
        {
            DataManager.Instance.StoreKey(ID);
            AudioManager.Instance.PlaySFX(GeneralSFX.KeyTaken);
        }

        public float floatAmplitude = 0.5f;
        public float floatFrequency = 1f;
        public float floatSpeed = 1f;

        private Vector3 _initialPosition;

        void Start()
        {
            _initialPosition = transform.position;
        }

        void Update()
        {
            float newY = _initialPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;

            float newX = _initialPosition.x + Mathf.Cos(Time.time * floatFrequency) * floatAmplitude * floatSpeed;

            transform.position = new Vector3(newX, newY, _initialPosition.z);
        }

    }
}

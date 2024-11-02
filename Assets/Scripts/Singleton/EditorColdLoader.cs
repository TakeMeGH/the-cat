using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class EditorColdLoader : MonoBehaviour
    {
        [SerializeField] GameObject _audioManager;
        void Awake()
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager == null)
            {
                Instantiate(_audioManager, Vector3.zero, Quaternion.identity);
            }
        }
    }
}

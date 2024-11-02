using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class EditorColdLoader : MonoBehaviour
    {
        [SerializeField] GameObject _audioManager;
        [SerializeField] GameObject _dataManager;

        void Awake()
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            if (audioManager == null)
            {
                Instantiate(_audioManager, Vector3.zero, Quaternion.identity);
            }

            DataManager dataManager = FindObjectOfType<DataManager>();
            if (dataManager == null)
            {
                Instantiate(_dataManager, Vector3.zero, Quaternion.identity);
            }
        }
    }
}

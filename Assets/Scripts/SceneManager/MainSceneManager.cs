using System;
using UnityEngine;

namespace TC
{
    public class MainSceneManager : MonoBehaviour
    {
        [SerializeField] Transform _plyerStart;
        [SerializeField] GameObject _player;
        [SerializeField] VoidEvent _respawnEvent;
        [SerializeField] VoidEvent _gameoverEvent;
        [SerializeField] InputReader _inputReader;


        void OnEnable()
        {
            _respawnEvent.EventAction += OnRespawn;
        }

        void OnDisable()
        {
            _respawnEvent.EventAction -= OnRespawn;
        }

        void Start()
        {
            _inputReader.EnableGameplayInput();
        }

        void OnRespawn()
        {
            _player.transform.position = _plyerStart.position;
        }
    }
}

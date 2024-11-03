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

        [field: Header("UI")]
        [SerializeField] GameObject PauseMenu;
        [SerializeField] GameObject GameOverMenu;
        GameObject _selectedMenu = null;


        void OnEnable()
        {
            _respawnEvent.EventAction += OnRespawn;
            _gameoverEvent.EventAction += OnGameOver;
        }

        void OnDisable()
        {
            _respawnEvent.EventAction -= OnRespawn;
            _gameoverEvent.EventAction -= OnGameOver;

        }

        void Start()
        {
            _inputReader.EnableGameplayInput();
        }

        void OnRespawn()
        {
            _player.transform.position = _plyerStart.position;
        }

        void OnGameOver()
        {
            if (_selectedMenu == PauseMenu)
            {
                ClosePauseMenu();
            }

            _selectedMenu = GameOverMenu;
            _selectedMenu.GetComponent<GameOverController>().OpenGameOver();
        }

        public void OpenPauseMenu()
        {
            if (_selectedMenu == null)
            {
                _selectedMenu = PauseMenu;
                _selectedMenu.GetComponent<PauseController>().PausePressed();
            }
        }

        public void ClosePauseMenu()
        {
            if (_selectedMenu == PauseMenu)
            {
                _selectedMenu.GetComponent<PauseController>().PausePressed();
                _selectedMenu = null;
            }
        }

    }
}

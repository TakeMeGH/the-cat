using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class PauseController : MonoBehaviour
    {
        [SerializeField] InputReader _inputReader;
        [SerializeField] GameObject _pauseMenuUI;

        bool _gameIsPaused = false;

        public void PausePressed()
        {
            if (_gameIsPaused)
            {
                Resume();
            }
            else
            {
                StartCoroutine(Pause());
            }
        }

        void Resume()
        {
            Time.timeScale = 1f;
            _inputReader.EnableGameplayInput();
            _gameIsPaused = false;
            _pauseMenuUI.SetActive(false);

        }

        IEnumerator Pause()
        {
            _inputReader.EnableUIInput();
            _pauseMenuUI.SetActive(true);
            _gameIsPaused = true;
            yield return new WaitForEndOfFrame();
            Time.timeScale = 0f;
        }
    }
}

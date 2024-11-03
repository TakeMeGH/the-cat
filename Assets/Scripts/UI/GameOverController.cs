using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverContainer;
        [SerializeField] InputReader _inputReader;


        public void OpenGameOver()
        {
            AudioManager.Instance.PlaySFX(GeneralSFX.Ded);
            _gameOverContainer.SetActive(true);
            DataManager.Instance.ClearData();
            _inputReader.EnableUIInput();
        }
    }
}

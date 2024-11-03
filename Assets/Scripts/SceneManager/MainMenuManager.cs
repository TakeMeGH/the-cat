using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] InputReader _inputReader;
        [SerializeField] GameObject _settingsMenu;
        [SerializeField] GameObject _creditsMenu;
        [SerializeField] GameObject _tutorialMenu;

        GameObject _selectedMenu = null;

        void Start()
        {
            _inputReader.EnableUIInput();
            AudioManager.Instance.PlayBGM(GeneraBGM.MainMenu);
        }

        public void OpenSettingsMenu()
        {
            if (_selectedMenu == null)
            {
                _selectedMenu = _settingsMenu;
                _selectedMenu.SetActive(true);
                _selectedMenu.GetComponent<VolumeSettings>().Setup();
            }
        }

        public void OpenCreditsMenu()
        {
            _selectedMenu = _creditsMenu;
            _selectedMenu.SetActive(true);
        }

        public void OpenTutorialMenu()
        {
            _selectedMenu = _tutorialMenu;
            _selectedMenu.SetActive(true);

        }


        public void CloseMenu()
        {
            if (_selectedMenu != null)
            {
                _selectedMenu.SetActive(false);
                _selectedMenu = null;
            }
        }

    }
}

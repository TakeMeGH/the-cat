using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


namespace TC
{
    public class MainSceneManager : MonoBehaviour
    {
        [field: Header("Player")]
        [SerializeField] Transform _plyerStart;
        [SerializeField] GameObject _player;
        [SerializeField] VoidEvent _respawnEvent;
        [SerializeField] VoidEvent _gameoverEvent;
        [SerializeField] InputReader _inputReader;

        [field: Header("UI")]
        [SerializeField] GameObject PauseMenu;
        [SerializeField] GameObject GameOverMenu;
        GameObject _selectedMenu = null;

        [field: Header("Last Level")]
        [SerializeField] VoidEvent _onLastLevel;
        [SerializeField] CinemachineVirtualCamera _virtualCamera;
        [SerializeField] Volume _postProcessVolume;
        [SerializeField] MCController _MCController;


        void OnEnable()
        {
            _respawnEvent.EventAction += OnRespawn;
            _gameoverEvent.EventAction += OnGameOver;
            _onLastLevel.EventAction += OnLastLevel;
        }
        void OnDisable()
        {
            _respawnEvent.EventAction -= OnRespawn;
            _gameoverEvent.EventAction -= OnGameOver;
            _onLastLevel.EventAction -= OnLastLevel;

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

        void OnLastLevel()
        {
            _virtualCamera.m_Lens.FieldOfView = 25;

            var noise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            noise.m_AmplitudeGain = 3f;
            noise.m_FrequencyGain = 0.37f;

            Vignette vignette;

            if (_postProcessVolume.profile.TryGet(out vignette))
            {
                vignette.active = true;
            }

            _MCController.IsUsingDelay = true;

        }


    }
}

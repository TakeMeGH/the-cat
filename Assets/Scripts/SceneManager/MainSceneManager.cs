using System.Collections;
using Cinemachine;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
        [SerializeField] VoidEvent _onAlarm;
        [SerializeField] VoidEvent _onFinishGame;
        [SerializeField] CinemachineVirtualCamera _virtualCamera;
        [SerializeField] Volume _postProcessVolume;
        [SerializeField] MCController _MCController;
        [SerializeField] DoorManager _lastDoor;
        [SerializeField] DoorManager _lastDoor2;

        [SerializeField] GameObject _playerStart;
        [SerializeField] Transform _newPlayerStartLocation;
        [SerializeField] string _nextScene;
        [SerializeField] CanvasGroup _HUD;
        [SerializeField] Image _blackScreen;
        [SerializeField] float _transitionDuration = 1f;
        float _initialFieldOfView;
        float _targetFieldOfView;

        float _elapsedTime = 0f;
        bool _isTransitioningFOV = false;
        void OnEnable()
        {
            _respawnEvent.EventAction += OnRespawn;
            _gameoverEvent.EventAction += OnGameOver;
            _onLastLevel.EventAction += OnLastLevel;
            _onFinishGame.EventAction += OnFinishGame;
            _onAlarm.EventAction += OnAlarm;
        }
        void OnDisable()
        {
            _respawnEvent.EventAction -= OnRespawn;
            _gameoverEvent.EventAction -= OnGameOver;
            _onLastLevel.EventAction -= OnLastLevel;
            _onFinishGame.EventAction -= OnFinishGame;
            _onAlarm.EventAction -= OnAlarm;

        }

        void Start()
        {
            _inputReader.EnableGameplayInput();
            AudioManager.Instance.PlayBGM(GeneraBGM.InGame);
        }

        void Update()
        {
            if (_isTransitioningFOV)
            {
                _elapsedTime += Time.deltaTime;

                float t = _elapsedTime / _transitionDuration;

                _virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(_initialFieldOfView, _targetFieldOfView, t);

                if (_elapsedTime >= _transitionDuration)
                {
                    _virtualCamera.m_Lens.FieldOfView = _targetFieldOfView;
                    _isTransitioningFOV = false;
                }
            }

        }

        void OnRespawn()
        {
            DataManager.Instance.RemoveWater();
            _player.transform.position = _plyerStart.position;
        }

        void OnGameOver()
        {
            if (_selectedMenu == PauseMenu)
            {
                ClosePauseMenu();
            }

            _HUD.alpha = 0;
            _selectedMenu = GameOverMenu;
            _selectedMenu.GetComponent<GameOverController>().OpenGameOver();
        }

        public void OpenPauseMenu()
        {
            if (_selectedMenu == null)
            {
                _selectedMenu = PauseMenu;
                _HUD.alpha = 0;
                _selectedMenu.GetComponent<PauseController>().PausePressed();
            }
        }

        public void ClosePauseMenu()
        {
            if (_selectedMenu == PauseMenu)
            {
                _selectedMenu.GetComponent<PauseController>().PausePressed();
                _selectedMenu = null;
                _HUD.alpha = 1;
            }
        }

        void OnLastLevel()
        {
            AudioManager.Instance.PlayBGM(GeneraBGM.NRoom);

            _initialFieldOfView = _virtualCamera.m_Lens.FieldOfView;
            _elapsedTime = 0f;
            _isTransitioningFOV = true;
            _targetFieldOfView = 25;

            var noise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            noise.m_AmplitudeGain = 3f;
            noise.m_FrequencyGain = 0.37f;

            Vignette vignette;

            if (_postProcessVolume.profile.TryGet(out vignette))
            {
                vignette.active = true;
            }

            _MCController.IsUsingDelay = true;
            _lastDoor.open = false;
            _lastDoor2.open = false;

            _playerStart.transform.position = _newPlayerStartLocation.transform.position;
        }

        void OnFinishGame()
        {
            StartCoroutine(OnFinishGameCoroutine());
        }

        IEnumerator OnFinishGameCoroutine()
        {
            _inputReader.EnableUIInput();

            _HUD.alpha = 0;

            DepthOfField depthOfField;

            if (_postProcessVolume.profile.TryGet(out depthOfField))
            {
                depthOfField.active = true;
            }

            _virtualCamera.m_Lens.FieldOfView = 10;

            var noise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            noise.m_AmplitudeGain = 0f;
            noise.m_FrequencyGain = 0f;


            yield return new WaitForSeconds(2);

            _blackScreen.color = Color.black;

            yield return new WaitForSeconds(1);

            SceneManager.LoadScene(_nextScene);
        }

        public void OnAlarm()
        {
            _MCController.Speed = _MCController.SlowSpeed;
        }
    }
}

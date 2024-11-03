using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class HUDManager : MonoBehaviour
    {
        [SerializeField] List<HPIconManager> HPIconManagers = new List<HPIconManager>();
        [SerializeField] VoidEvent _respawnEvent;
        [SerializeField] VoidEvent _gameOverEvent;
        int _lastIndex;
        void OnEnable()
        {
            _respawnEvent.EventAction += RemoveOneHP;
            _gameOverEvent.EventAction += RemoveOneHP;

        }

        void OnDisable()
        {
            _respawnEvent.EventAction -= RemoveOneHP;
            _gameOverEvent.EventAction -= RemoveOneHP;
        }

        void Start()
        {
            _lastIndex = HPIconManagers.Count - 1;
        }

        void RemoveOneHP()
        {
            if (_lastIndex >= 0)
            {
                HPIconManagers[_lastIndex].TurnOff();
                _lastIndex--;
            }
        }
    }
}

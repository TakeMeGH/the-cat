using UnityEngine;
using UnityEngine.Events;

namespace TC
{
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool, GameObject> { }
    public class ZoneTriggerController : MonoBehaviour
    {
        [SerializeField] private BoolEvent _enterZone = default;

        private void OnTriggerEnter(Collider other)
        {
            _enterZone.Invoke(true, other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            _enterZone.Invoke(false, other.gameObject);
        }
    }
}

using DoorScript;
using UnityEngine;

namespace TC
{
    public class DoorManager : MonoBehaviour
    {
        public string ID;
        public bool open;
        public float smooth = 1.0f;
        public float DoorOpenAngle = 90f;
        public float DoorCloseAngle = 0.0f;
        [SerializeField] BoxCollider _box;
        [SerializeField] DoorManager _connectDoor;

        void Update()
        {
            if (open)
            {
                _box.enabled = false;
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);

            }
            else
            {
                _box.enabled = true;
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);

            }
        }

        public void OpenDoor()
        {
            if (DataManager.Instance.CheckKey(ID))
            {
                open = true;
                if (_connectDoor != null)
                {
                    _connectDoor.OpenSolo();
                }
            }
        }

        public void OpenSolo()
        {
            if (DataManager.Instance.CheckKey(ID))
            {
                open = true;
            }
        }

    }
}

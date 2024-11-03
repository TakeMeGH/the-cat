using UnityEngine;

namespace TC
{
    public class DoorManager : MonoBehaviour
    {
        public string ID;
        public bool open;
        public float smooth = 1.0f;
        float DoorOpenAngle = -90.0f;
        float DoorCloseAngle = 0.0f;

        void Update()
        {
            if (open)
            {
                var target = Quaternion.Euler(0, DoorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);

            }
            else
            {
                var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);

            }
        }

        public void OpenDoor()
        {
            if (DataManager.Instance.CheckKey(ID))
            {
                open = true;
            }
        }

    }
}

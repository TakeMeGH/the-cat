using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class AlarmManager : MonoBehaviour
    {
        [SerializeField] VoidEvent _alarm;

        public void Alarm()
        {
            DataManager.Instance.SetAlarmIspressed(true);
            _alarm.RaiseEvent();
        }
    }
}

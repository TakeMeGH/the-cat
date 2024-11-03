using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TC
{
    public class DataManager : Singleton<DataManager>
    {
        public List<string> IsKeyExist = new List<string>();
        bool _isTowelExist;
        bool _isWaterExist;
        bool _isRemoveWaterNext;
        public UnityAction OnTowelStatusChange;
        public UnityAction OnWaterStatusChange;

        public void StoreKey(string ID)
        {
            IsKeyExist.Add(ID);
        }

        public bool CheckKey(string ID)
        {
            return IsKeyExist.Contains(ID);
        }

        public void ClearData()
        {
            IsKeyExist = new List<string>();
            _isTowelExist = false;
            _isWaterExist = false;
        }

        public void SetTowelExist(bool value)
        {
            _isTowelExist = value;
            OnTowelStatusChange?.Invoke();
        }

        public bool IsTowelExist()
        {
            return _isTowelExist;
        }

        public void SetWaterExist(bool value)
        {
            _isWaterExist = value;
            OnWaterStatusChange.Invoke();
        }

        public bool IsWaterExist()
        {
            return _isWaterExist;
        }

        public void RemoveWater()
        {
            _isWaterExist = false;
            _isRemoveWaterNext = false;
            OnWaterStatusChange.Invoke();
        }

        public void SetRemoveWater(bool value)
        {
            _isRemoveWaterNext = value;
        }

        public bool IsRemoveWater()
        {
            return _isRemoveWaterNext;
        }


    }
}

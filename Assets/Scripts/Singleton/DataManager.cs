using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class DataManager : Singleton<DataManager>
    {
        public List<string> IsKeyExist;
        public bool IsTowelExist;
        public bool IsWaterExist;

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
            IsKeyExist.Clear();
        }

    }
}

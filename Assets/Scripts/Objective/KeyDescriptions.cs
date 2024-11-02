using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class KeyDescriptions : MonoBehaviour
    {
        [SerializeField] public string ID;
        public void StoreKey()
        {
            DataManager.Instance.StoreKey(ID);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class RemoveWaterMark : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            DataManager.Instance.SetRemoveWater(true);
        }
    }
}

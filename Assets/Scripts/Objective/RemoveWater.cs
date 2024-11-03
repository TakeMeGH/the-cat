using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class RemoveWater : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (DataManager.Instance.IsRemoveWater())
            {
                DataManager.Instance.RemoveWater();
            }
        }

    }
}

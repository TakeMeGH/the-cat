using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class Water : MonoBehaviour
    {
        public void PickUpWater()
        {
            DataManager.Instance.SetWaterExist(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class Towel : MonoBehaviour
    {
        public void PickUpTowel()
        {
            DataManager.Instance.SetTowelExist(true);
        }
    }
}

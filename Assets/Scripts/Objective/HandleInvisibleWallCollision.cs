using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class HandleInvisibleWallCollision : MonoBehaviour
    {
        [SerializeField] BoxCollider _invisibleWall;

        void OnEnable()
        {
            DataManager.Instance.OnTowelStatusChange += SetWallStatus;
            DataManager.Instance.OnWaterStatusChange += SetWallStatus;
        }

        void OnDisable()
        {
            DataManager.Instance.OnTowelStatusChange -= SetWallStatus;
            DataManager.Instance.OnWaterStatusChange -= SetWallStatus;
        }

        void SetWallStatus()
        {
            if (DataManager.Instance.IsWaterExist() && DataManager.Instance.IsTowelExist())
            {
                _invisibleWall.enabled = false;
            }
            else
            {
                _invisibleWall.enabled = true;
            }
        }
    }
}

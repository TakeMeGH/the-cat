using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class Billboard : MonoBehaviour
    {
        Transform Cam;

        void Start()
        {
            Cam = Camera.main.transform;
        }

        void LateUpdate()
        {
            transform.LookAt(transform.position + Cam.forward);
        }
    }
}

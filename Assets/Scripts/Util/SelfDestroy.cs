using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class SelfDestroy : MonoBehaviour
    {
        public void Sucide()
        {
            Destroy(gameObject);
        }
    }
}

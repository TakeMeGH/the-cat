using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace TC
{
    public class HPIconManager : MonoBehaviour
    {
        [SerializeField] GameObject _xIcon;

        public void TurnOff()
        {
            _xIcon.SetActive(true);
        }
    }
}
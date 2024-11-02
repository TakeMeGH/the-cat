using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] InputReader _inputReader;

        void Start()
        {
            _inputReader.EnableUIInput();
        }
    }
}

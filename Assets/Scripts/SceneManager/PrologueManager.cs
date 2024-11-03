using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class PrologueManager : MonoBehaviour
    {
        void Start()
        {
            AudioManager.Instance.PlayBGM(GeneraBGM.MainMenu);
        }
    }
}

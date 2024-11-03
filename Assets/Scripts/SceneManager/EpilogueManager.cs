using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class EpilogueManager : MonoBehaviour
    {
        void Start()
        {
            AudioManager.Instance.PlayBGM(GeneraBGM.WinningScene);
        }
    }
}

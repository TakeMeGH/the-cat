using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class PlayAudioFromAnimation : MonoBehaviour
    {
        public void PlayWalk()
        {
            AudioManager.Instance.PlaySFX(GeneralSFX.Walking);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace TC
{

    public enum GeneralSFX
    {
        ExampleSFX,
    }

    public enum GeneraBGM
    {
        ExampleBGM,
    }


    public class AudioManager : Singleton<AudioManager>
    {

        [SerializeField] AudioMixer _mixer;
        const string MASTER_VOLUME = "MasterVolume";
        const string SFX_VOLUME = "SFXVolume";
        const string BGM_VOLUME = "BGMVolume";
        const float MULTIPILER = 20;

        #region SFX
        [SerializeField] AudioSource _exampleSFX;
        // here
        #endregion

        #region BGM
        [SerializeField] AudioSource _exampleBGM;
        // here
        #endregion

        void Start()
        {
            LoadMixer();
        }

        void LoadMixer()
        {
            if (!PlayerPrefs.HasKey(MASTER_VOLUME))
            {
                return;
            }

            float volume = PlayerPrefs.GetFloat(MASTER_VOLUME);
            _mixer.SetFloat(MASTER_VOLUME, Mathf.Log10(volume) * MULTIPILER);
            PlayerPrefs.SetFloat(MASTER_VOLUME, volume);

            volume = PlayerPrefs.GetFloat(SFX_VOLUME);
            _mixer.SetFloat(SFX_VOLUME, Mathf.Log10(volume) * MULTIPILER);
            PlayerPrefs.SetFloat(SFX_VOLUME, volume);

            volume = PlayerPrefs.GetFloat(BGM_VOLUME);
            _mixer.SetFloat(BGM_VOLUME, Mathf.Log10(volume) * MULTIPILER);
            PlayerPrefs.SetFloat(BGM_VOLUME, volume);
        }
    }
}

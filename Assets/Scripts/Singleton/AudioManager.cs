using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace TC
{

    public enum GeneralSFX
    {
        Jumping,
        Walking,
        Dipping,
        Ded,
        DoorOpen,
        Fire,
        KeyTaken,
        DraggingBox,
        IdleMeow,
        FireHit,
    }

    public enum GeneraBGM
    {
        WinningScene,
        InGame,
        MainMenu,
        NRoom,
    }


    public class AudioManager : Singleton<AudioManager>
    {

        [SerializeField] AudioMixer _mixer;
        const string MASTER_VOLUME = "MasterVolume";
        const string SFX_VOLUME = "SFXVolume";
        const string BGM_VOLUME = "BGMVolume";
        const float MULTIPILER = 20;

        #region SFX
        [SerializeField] AudioSource Jumping;
        [SerializeField] AudioSource Walking;
        [SerializeField] AudioSource Dipping;
        [SerializeField] AudioSource Ded;
        [SerializeField] AudioSource DoorOpen;
        [SerializeField] AudioSource Fire;
        [SerializeField] AudioSource KeyTaken;
        [SerializeField] AudioSource DraggingBox;
        [SerializeField] AudioSource IdleMeow;
        [SerializeField] AudioSource FireHit;
        #endregion

        #region BGM
        [SerializeField] AudioSource WinningScene;
        [SerializeField] AudioSource InGame;
        [SerializeField] AudioSource MainMenu;
        [SerializeField] AudioSource NRoom;
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

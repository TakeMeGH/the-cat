using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TC
{
    public class KeyListener : MonoBehaviour
    {
        [SerializeField] InputReader _inputReader;
        [SerializeField] UnityEvent OnSpacePress;
        [SerializeField] UnityEvent OnStartGamePress;
        [SerializeField] UnityEvent OnOpenPausePress;
        [SerializeField] UnityEvent OnClosePausePress;

        void OnEnable()
        {
            _inputReader.JumpEvent += OnSpacePressed;
            _inputReader.StartGameEvent += OnStartGamePressed;
            _inputReader.OpenPauseEvent += OnOpenPausePressed;
            _inputReader.ClosePauseEvent += OnClosedPausePressed;

        }

        void OnDisable()
        {
            _inputReader.JumpEvent -= OnSpacePressed;
            _inputReader.StartGameEvent -= OnStartGamePressed;
            _inputReader.OpenPauseEvent -= OnOpenPausePressed;
            _inputReader.ClosePauseEvent -= OnClosedPausePressed;
        }

        void OnSpacePressed()
        {
            OnSpacePress?.Invoke();
        }

        void OnStartGamePressed()
        {
            OnStartGamePress?.Invoke();
        }

        void OnOpenPausePressed()
        {
            OnOpenPausePress.Invoke();
        }

        void OnClosedPausePressed()
        {
            OnClosePausePress?.Invoke();
        }




    }
}


using UnityEngine;

namespace TC
{
    public class MCDamagedState : IState
    {
        protected MCController _MCController;

        Material _originalMaterial;
        private float _toggleTimer;
        private float _flashTimer;
        private bool _isFlashing;
        bool _currentlyFlashMaterial;
        const string ANIMATION_NAME = "MC_Idle";

        public MCDamagedState(MCController _MCController)
        {
            this._MCController = _MCController;
        }

        public void Enter()
        {
            _MCController.Rigidbody.velocity = new Vector3(0, _MCController.Rigidbody.velocity.y, 0);
            _originalMaterial = _MCController.SpriteRenderer.material;
            _currentlyFlashMaterial = false;
            _MCController.Animator.Play(ANIMATION_NAME);

            StartFlashing();
        }

        public void Exit()
        {
            if (_MCController.CurrentHealth > 0)
            {
                _MCController.OnRespawnEvent.RaiseEvent();
            }
            else
            {
                _MCController.OnGameOverEvent.RaiseEvent();
            }
        }

        public void PhysicsUpdate()
        {
        }

        public void Update()
        {
            if (_isFlashing)
            {
                _toggleTimer -= Time.deltaTime;
                _flashTimer -= Time.deltaTime;
                if (_toggleTimer <= 0f)
                {
                    _toggleTimer = _MCController.FlashInterval;
                    ToggleFlash();
                }

                if (_flashTimer <= 0)
                {
                    StopFlashing();
                }
            }

        }


        private void ToggleFlash()
        {
            Debug.Log(_currentlyFlashMaterial);
            if (_currentlyFlashMaterial)
            {
                _currentlyFlashMaterial = !_currentlyFlashMaterial;
                _MCController.SpriteRenderer.material = _originalMaterial;
            }
            else
            {
                _currentlyFlashMaterial = !_currentlyFlashMaterial;
                _MCController.SpriteRenderer.material = _MCController.FlashMaterial;
            }
        }

        public void StartFlashing()
        {
            _isFlashing = true;
            _toggleTimer = _MCController.FlashInterval;
            _flashTimer = _MCController.FlashDuration;
        }

        public void StopFlashing()
        {
            _isFlashing = false;
            _MCController.SpriteRenderer.material = _originalMaterial;
            _MCController.SwitchState(_MCController.MCIdlingState);
        }

    }
}

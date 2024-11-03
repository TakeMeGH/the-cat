using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class InteractionManager : MonoBehaviour
    {
        [SerializeField] InputReader _inputReader = default;
        List<CustomInteractable> _potentialInteractions = new List<CustomInteractable>();
        CustomInteractable _currentInteraction;
        // private void OnEnable()
        // {
        //     _inputReader.InteractEvent += OnInteractionButtonPress;
        // }

        // private void OnDisable()
        // {
        //     _inputReader.InteractEvent -= OnInteractionButtonPress;
        // }

        public bool IsCanInteract()
        {
            if (_potentialInteractions.Count == 0)
            {
                return false;
            }

            if (_currentInteraction.IsInteractable == false)
            {
                return false;
            }

            return true;
        }
        public void OnInteractionButtonPress()
        {
            if (_potentialInteractions.Count == 0)
            {
                return;
            }

            if (_currentInteraction.IsInteractable == false)
            {
                return;
            }
            _currentInteraction.Interact();
            RemovePotentialInteraction(_currentInteraction.gameObject);

        }
        public void OnTriggerChangeDetected(bool entered, GameObject obj)
        {
            if (entered)
                AddPotentialInteraction(obj);
            else
                RemovePotentialInteraction(obj);
        }

        private void AddPotentialInteraction(GameObject obj)
        {
            if (obj.TryGetComponent<CustomInteractable>(out CustomInteractable currentInteraction))
            {
                if (currentInteraction.IsInteractable == false)
                {
                    return;
                }

                if (_potentialInteractions.Count == 0)
                {
                    _currentInteraction = currentInteraction;
                    currentInteraction.InteractIndicator.enabled = true;
                }
                _potentialInteractions.Add(currentInteraction);
            }
        }

        private void RemovePotentialInteraction(GameObject obj)
        {
            if (obj.TryGetComponent<CustomInteractable>(out CustomInteractable currentInteraction))
            {
                for (int i = 0; i < _potentialInteractions.Count; i++)
                {
                    if (_potentialInteractions[i] == currentInteraction)
                    {
                        _potentialInteractions.RemoveAt(i);
                        currentInteraction.InteractIndicator.enabled = false;
                        break;
                    }
                }
            }
        }
    }
}

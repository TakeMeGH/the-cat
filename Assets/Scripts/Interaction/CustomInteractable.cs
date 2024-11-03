using UnityEngine;
using UnityEngine.Events;

namespace TC
{
    public class CustomInteractable : MonoBehaviour, IInteractable
    {
        public UnityEvent<Component> FunctionTrigger;
        public SpriteRenderer InteractIndicator;
        public bool IsInteractable = true;

        private void Start()
        {
            SetInteractable(IsInteractable);
        }

        public void SetInteractable(bool state)
        {
            IsInteractable = state;
            if (state == false) InteractIndicator.enabled = state;
        }
        public void Interact()
        {
            FunctionTrigger?.Invoke(this);
        }
    }
}

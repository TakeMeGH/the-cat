using UnityEngine;
using UnityEngine.Events;

namespace TC
{

    [CreateAssetMenu(fileName = "New BubbleIconEvent", menuName = "Events/Bubble Icon Event")]
    public class BubbleIconEvent : ScriptableObject
    {
        public UnityAction<Sprite, float> EventAction;

        public void RaiseEvent(Sprite sprite, float duration)
        {
            EventAction?.Invoke(sprite, duration);
        }
    }
}

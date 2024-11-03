using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TC
{
    public class BubbleIconManager : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _bubbleSprite;
        [SerializeField] SpriteRenderer _iconSprite;
        [SerializeField] BubbleIconEvent _bubbleEvent;
        float _duration;
        float _currentTime;
        bool _showing;
        void OnEnable()
        {
            _bubbleEvent.EventAction += OnShowBubble;
        }

        void OnDisable()
        {
            _bubbleEvent.EventAction -= OnShowBubble;
        }

        private void Update()
        {
            if (_currentTime + _duration < Time.time)
            {
                HideSprite();
            }
        }

        void OnShowBubble(Sprite sprite, float duration)
        {
            _duration = duration;
            _currentTime = Time.time;
            ShowSprite(sprite);
        }

        void ShowSprite(Sprite sprite)
        {
            _bubbleSprite.enabled = true;
            _iconSprite.enabled = true;
            _iconSprite.sprite = sprite;
            _showing = true;
        }

        void HideSprite()
        {
            if (!_showing) return;
            _showing = false;
            _bubbleSprite.enabled = false;
            _iconSprite.enabled = false;
        }
    }
}

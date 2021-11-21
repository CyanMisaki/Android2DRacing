using System;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace CustomUI
{
    [Serializable]
    public class CustomButton : Button
    {
        public const string TypeFieldName = nameof(_animationType);
        public const string DurationFieldName = nameof(_duration);
        public const string PowerFieldName = nameof(_animationPower);
        public const string EasingFieldName = nameof(_easing);
        
        
        [SerializeField] private AnimationType _animationType;
        [SerializeField] private float _duration = 0.4f;
        [SerializeField] private float _animationPower = 0.5f;
        [SerializeField] private Ease _easing = Ease.InBounce;
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            ShowAnimation(eventData);
        }

        private void ShowAnimation(PointerEventData eventData)
        {
            switch(_animationType)
            {
                case AnimationType.None:
                    break;
                case AnimationType.Scale:
                    transform.DOPunchScale(Vector3.one * (1 + _animationPower), _duration, 3)
                        .SetEase(_easing)
                        .OnComplete(()=>base.OnPointerClick(eventData));
                    break;
                case AnimationType.Rotate:
                    transform.DOShakeRotation(_duration, _animationPower)
                        .SetEase(_easing)
                        .OnComplete(()=>base.OnPointerClick(eventData));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
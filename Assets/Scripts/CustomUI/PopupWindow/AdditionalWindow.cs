using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.PopupWindow
{
    public class AdditionalWindow : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private float _duration = 0.5f;
        
        [SerializeField] private float _headerDuration = 1f;
        [SerializeField] private float _textDuration = 1.5f;

        [SerializeField] private Text _header;
        [SerializeField] private Text _text;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Hide);
            ResetText();
        }

        private void ResetText()
        {
            _header.text = null;
            _text.text = null;
        }

        public void Hide()
        {
            var sequence = DOTween.Sequence();
            sequence.Insert(0f, transform.DOScale(Vector3.zero, _duration));
            sequence.OnComplete(() =>
            {
                transform.localScale = Vector3.zero;
                ResetText();
                gameObject.SetActive(false);
            });

        }

        public void Show()
        {
            gameObject.SetActive(true);
            transform.localScale = Vector3.zero;
           
            var sequence = DOTween.Sequence();
            sequence.Insert(0f, transform.DOScale(Vector3.one, _duration));
            sequence.Insert(0f, _header.DOText("Here must be your company header", _headerDuration).SetEase(Ease.Linear));
            sequence.Insert(0f, _text.DOText("Her must be information abput your company, your product, e.t.c", _textDuration).SetEase(Ease.Linear));
            sequence.OnComplete(() =>
            {
                transform.localScale = Vector3.one;
            });
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}
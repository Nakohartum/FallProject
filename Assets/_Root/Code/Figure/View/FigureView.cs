using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace _Root.Code.Figure.View
{
    public class FigureView : MonoBehaviour, IFigureView
    {
        [field: SerializeField] public SpriteRenderer BackgroundRenderer { get; private set; }
        [field: SerializeField] public SpriteRenderer ForegroundRenderer { get; private set; }
        public FigurePresenter.FigurePresenter FigurePresenter { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }

        public event Action OnClick = delegate { };
        private Color _disabledColor;
        private Color _enabledColor;

        public Vector3 Position => transform.position;
        public bool IsEnabled { get; private set; }

        public void Initialize(FigurePresenter.FigurePresenter figurePresenter)
        {
            FigurePresenter = figurePresenter;
        }

        public void SetBackgroundSprite(Sprite sprite)
        {
            BackgroundRenderer.sprite = sprite;
        }

        public void SetSprite(Sprite sprite)
        {
            ForegroundRenderer.sprite = sprite;
        }

        public void SetColor(Color color)
        {
            _enabledColor = color;
            _disabledColor = color.WithAlpha(0.2f);
        }

        public void SetEnabled(bool value)
        {
            IsEnabled = value;
            if (IsEnabled)
            {
                Debug.Log("Enabled");
                BackgroundRenderer.color = _enabledColor;
            }
            else
            {
                BackgroundRenderer.color = _disabledColor;
            }
        }

        private void OnDestroy()
        {
            FigurePresenter.Dispose();
        }


        public void PerformClick()
        {
            if (IsEnabled)
            {
                OnClick();
                GameEventBus.CallOnItemClicked();
            }
        }
    }
}
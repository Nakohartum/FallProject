using System;
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

        public event Action OnClick = delegate { };

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
            BackgroundRenderer.color = color;
        }

        

        public void PerformClick()
        {
            OnClick();
        }
    }
}
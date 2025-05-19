using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.Figure.View
{
    public class FigureCellView : MonoBehaviour
    {
        [field: SerializeField] public Image BackgroundRenderer { get; private set; }
        [field: SerializeField] public Image ForegroundRenderer { get; private set; }
        public FigurePresenter.FigurePresenter FigurePresenter { get; private set; }
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

        public void ResetView()
        {
            BackgroundRenderer.color = Color.white;
            BackgroundRenderer.sprite = null;
            ForegroundRenderer.sprite = null;
            FigurePresenter = null;
        }
    }
}
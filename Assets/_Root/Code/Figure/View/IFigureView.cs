using System;
using UnityEngine;

namespace _Root.Code.Figure.View
{
    public interface IFigureView
    {
        public SpriteRenderer BackgroundRenderer{ get; }
        public SpriteRenderer ForegroundRenderer { get; }
        FigurePresenter.FigurePresenter FigurePresenter { get; }
        public Rigidbody2D Rigidbody2D{ get; }
        public event Action OnClick;
        
        public Vector3 Position { get; }
        public bool IsEnabled { get; }

        public void Initialize(FigurePresenter.FigurePresenter figurePresenter);
    

        public void SetBackgroundSprite(Sprite sprite);

        public void SetSprite(Sprite sprite);
        public void SetColor(Color color);
        public void SetEnabled(bool value);

    }
}
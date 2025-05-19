using _Root.Code.Figure.View;
using UnityEngine;

namespace _Root.Code.Figure
{
    public class FigureCellFactory
    {
        public void RemakeFigureCell(FigureCellView figureCellView, Sprite sprite, Sprite backgroundSprite, Color color, FigurePresenter.FigurePresenter presenter)
        {
            figureCellView.SetSprite(sprite);
            figureCellView.SetColor(color);
            figureCellView.SetBackgroundSprite(backgroundSprite);
            figureCellView.Initialize(presenter);
        }
    }
}
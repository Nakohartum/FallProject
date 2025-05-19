using System;
using _Root.Code.Figure.View;
using UnityEngine;

namespace _Root.Code.Figure.Model
{
    public class FigureModel : IComparable<FigureModel>
    {
        public FigureType FigureType { get; private set; }
        public FigureView FigureView { get; private set; }
        public Sprite Sprite { get; private set; }
        public Sprite BackgroundSprite { get; private set; }
        public Color Color { get; private set; }
        

        public FigureModel(FigureType figureType, FigureView figureView)
        {
            FigureType = figureType;
            FigureView = figureView;
            Sprite = FigureView.ForegroundRenderer.sprite;
            BackgroundSprite = FigureView.BackgroundRenderer.sprite;
            Color = FigureView.BackgroundRenderer.color;
        }

        public int CompareTo(FigureModel other)
        {
            if (FigureType == other.FigureType 
                && Sprite == other.Sprite 
                && BackgroundSprite == other.BackgroundSprite
                && Color == other.Color)
            {
                return 0;
            }

            return 1;
        }
    }
}
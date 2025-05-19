using System;
using _Root.Code.Figure.Model;
using _Root.Code.Figure.View;
using _Root.Code.ScoreFeature;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Root.Code.Figure.FigurePresenter
{
    public class FigurePresenter : IComparable<FigurePresenter>
    {
        public FigureModel FigureModel { get; private set; }
        private ScorePresenter _scorePresenter;
        private FigureCellFactory _figureCellFactory;

        public FigurePresenter(FigureModel figureModel, ScorePresenter scorePresenter, FigureCellFactory figureCellFactory)
        {
            FigureModel = figureModel;
            _scorePresenter = scorePresenter;
            _figureCellFactory = figureCellFactory;
            FigureModel.FigureView.OnClick += FigureViewOnOnClick;
        }

        private void FigureViewOnOnClick()
        {
            var sprite = FigureModel.FigureView.ForegroundRenderer.sprite;
            var color = FigureModel.FigureView.BackgroundRenderer.color;
            var backgroundSprite = FigureModel.FigureView.BackgroundRenderer.sprite;
            var figureCellView = _scorePresenter.GetFigureCellView();
            _figureCellFactory.RemakeFigureCell(figureCellView, sprite, backgroundSprite, color, this);
            _scorePresenter.CheckCells();
            Object.Destroy(FigureModel.FigureView.gameObject);
        }

        public int CompareTo(FigurePresenter other)
        {
            if (other == null)
            {
                return 1;
            }
            return FigureModel.CompareTo(other.FigureModel);
        }
    }
}
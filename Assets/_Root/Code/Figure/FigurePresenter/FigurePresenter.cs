using System;
using _Root.Code.Figure.Model;
using _Root.Code.Figure.View;
using _Root.Code.ScoreFeature;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Root.Code.Figure.FigurePresenter
{
    public class FigurePresenter : IComparable<FigurePresenter>, IDisposable
    {
        public FigureModel FigureModel { get; private set; }
        private ScorePresenter _scorePresenter;
        private FigureCellFactory _figureCellFactory;
        private GameManager _gameManager;
        public FigurePresenter(FigureModel figureModel, ScorePresenter scorePresenter, FigureCellFactory figureCellFactory, GameManager gameManager)
        {
            FigureModel = figureModel;
            _scorePresenter = scorePresenter;
            _figureCellFactory = figureCellFactory;
            _gameManager = gameManager;
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
            _gameManager.MinusFigure();
        }

        public int CompareTo(FigurePresenter other)
        {
            if (other == null)
            {
                return 1;
            }
            return FigureModel.CompareTo(other.FigureModel);
        }

        public void Dispose()
        {
            FigureModel.FigureView.OnClick -= FigureViewOnOnClick;
        }
    }
}
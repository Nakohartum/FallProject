using System;
using _Root.Code.ClampFeature;
using _Root.Code.Figure;
using _Root.Code.InputFeature;
using _Root.Code.ScoreFeature;
using UnityEngine;

namespace _Root.Code
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private ClampBootstrap _clampBootstrap;
        [SerializeField] private FigureBootstrap _figureBootstrap;
        [SerializeField] private int _thingsToSpawn;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private ScoreBootstrap _scoreBootstrap;
        private InputHandler _inputHandler;


        private void Start()
        {
            _scoreBootstrap.Initialize();
            _clampBootstrap.Initialize();
            _figureBootstrap.Initialize(_clampBootstrap.Thickness, _scoreBootstrap.ScorePresenter);
            _gameManager.CreateObjects(_thingsToSpawn, _figureBootstrap.FigureFactory);
            _inputHandler = new InputHandler();
        }

        private void Update()
        {
            _inputHandler.Execute();
        }
    }
}
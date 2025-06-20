using System;
using System.Collections.Generic;
using _Root.Code.EditorHelper;
using _Root.Code.Figure.FigureBehaviour;
using _Root.Code.Figure.Model;
using _Root.Code.Figure.View;
using _Root.Code.ScoreFeature;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace _Root.Code.Figure
{
    public class FigureFactory
    {
        private Sprite[] _sprites;
        private Dictionary<FigureType, Sprite> _backgroundSprites;
        private Color[] _colors;
        private FigureView _figureViewPrefab;
        private Vector3 _bottomLeft;
        private Vector3 _topRight;
        private readonly float _thickness;
        private FigureCellFactory _figureCellFactory;
        private ScorePresenter _scorePresenter;
        private GameManager _gameManager;
        public List<FigureView> FigureViews { get; private set; }
        

        public FigureFactory(Sprite[] sprites, Color[] colors, FigureView figureViewPrefab, 
            SpriteToEnum<FigureType>[] backgroundSprites, float thickness, FigureCellFactory figureCellFactory, 
            ScorePresenter scorePresenter, GameManager gameManager)
        {
            _sprites = sprites;
            _colors = colors;
            _figureViewPrefab = figureViewPrefab;
            _backgroundSprites = new Dictionary<FigureType, Sprite>();
            var camera = Camera.main;
            _bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
            _topRight = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            _thickness = thickness;
            _figureCellFactory = figureCellFactory;
            _scorePresenter = scorePresenter;
            _gameManager = gameManager;
            FigureViews = new List<FigureView>();
            foreach (var sprite in backgroundSprites)
            {
                _backgroundSprites.Add(sprite.Type, sprite.Sprite);
            }
        }

        public void CreateFigure()
        {
            var randomX = Random.Range(_bottomLeft.x + _thickness, _topRight.x - _thickness);
            var spawnY = _topRight.y + 1;
            var positionToSpawn = new Vector2(randomX, spawnY);
            var figure = Object.Instantiate(_figureViewPrefab, positionToSpawn, Quaternion.identity);
            SetRandomColor(figure);
            SetRandomSprite(figure);
            SetRandomBehaviour(figure);
            var figureType = SetRandomFigure(figure);
            var model = new FigureModel(figureType, figure);
            var presenter = new FigurePresenter.FigurePresenter(model,_scorePresenter, _figureCellFactory, _gameManager);
            figure.Initialize(presenter);
            FigureViews.Add(figure);
        }

        private void SetRandomBehaviour(IFigureView figure)
        {
            Debug.Log("We set random behaviour");
            var random = Random.Range(1, 5);
            figure.SetEnabled(true);
            switch (random)
            {
                case 1:
                    var frozenBehaviour = new FrozenBehaviour(figure);
                    frozenBehaviour.OnSpawn();
                    figure.SetEnabled(false);
                    break;
                case 2:
                    var heavyBehaviour = new HeavyBehaviour(figure);
                    heavyBehaviour.OnSpawn();
                    break;
                default:
                    break;
            }
        }

        public void CreateFigure(FigureType figureType, Color color)
        {
            var randomX = Random.Range(_bottomLeft.x + _thickness, _topRight.x - _thickness);
            var spawnY = _topRight.y + 1;
            var positionToSpawn = new Vector2(randomX, spawnY);
            var figure = Object.Instantiate(_figureViewPrefab, positionToSpawn, Quaternion.identity);
            figure.SetSprite(_sprites[1]);
            figure.SetColor(color);
            figure.SetBackgroundSprite(_backgroundSprites[figureType]);
            SetRandomBehaviour(figure);
            var model = new FigureModel(figureType, figure);
            var presenter = new FigurePresenter.FigurePresenter(model, _scorePresenter, _figureCellFactory, _gameManager);
            figure.Initialize(presenter);
            SetCollider(figureType, figure.gameObject);
            FigureViews.Add(figure);
        }

        private FigureType SetRandomFigure(FigureView figure)
        {
            var values = Enum.GetValues(typeof(FigureType));
            var length = values.Length;
            var figureType = (FigureType)values.GetValue(Random.Range(0, length));
            switch (figureType)
            {
                case FigureType.Circle:
                    figure.SetBackgroundSprite(_backgroundSprites[FigureType.Circle]);
                    SetCollider(FigureType.Circle, figure.gameObject);
                    break;
                case FigureType.Triangle:
                    figure.SetBackgroundSprite(_backgroundSprites[FigureType.Triangle]);
                    SetCollider(FigureType.Triangle, figure.gameObject);
                    break;
                case FigureType.Square:
                    figure.SetBackgroundSprite(_backgroundSprites[FigureType.Square]);
                    SetCollider(FigureType.Square, figure.gameObject);
                    break;
                case FigureType.Hexagon:
                    figure.SetBackgroundSprite(_backgroundSprites[FigureType.Hexagon]);
                    SetCollider(FigureType.Hexagon, figure.gameObject);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return figureType;
        }
        
        private void SetCollider(FigureType type, GameObject gameObject)
        {
            Object.Destroy(gameObject.GetComponent<Collider2D>());
            switch (type)
            {
                case FigureType.Circle:
                case FigureType.Triangle:
                case FigureType.Hexagon:
                    gameObject.AddComponent<CircleCollider2D>().radius = 0.5f;
                    break;
                case FigureType.Square:
                    gameObject.AddComponent<BoxCollider2D>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
        }

        private void SetRandomSprite(FigureView figure)
        {
            figure.SetSprite(_sprites[Random.Range(0, _sprites.Length)]);
        }

        private void SetRandomColor(FigureView figure)
        {
            figure.SetColor(_colors[Random.Range(0, _colors.Length)]);
        }

        public void DestroyFigures()
        {
            for (int i = 0; i < FigureViews.Count; i++)
            {
                if (FigureViews[i] == null) 
                {
                    continue;
                }
                Object.Destroy(FigureViews[i].gameObject);
            }

            FigureViews.Clear();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Root.Code.Figure;
using _Root.Code.Figure.View;
using _Root.Code.ScoreFeature;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = Unity.Mathematics.Random;

namespace _Root.Code
{
    public class GameManager : MonoBehaviour
    {
        private Coroutine _createFiguresRoutine;
        private int _currentAmount;
        private int _startingAmount;
        private FigureFactory _figureFactory;
        
        private ScorePresenter _scorePresenter;
        public event Action<GameState> OnGameConditionChanged;
        
        
        public void Initialize(FigureFactory figureFactory, ScorePresenter scorePresenter, int startingAmount)
        {
            _figureFactory = figureFactory;
            _scorePresenter = scorePresenter;
            _startingAmount = startingAmount;
        }
        
        public void CreateObjects()
        {
            _figureFactory.DestroyFigures();
            
            if (_createFiguresRoutine != null)
            {
                StopCoroutine(_createFiguresRoutine);
            }

            _createFiguresRoutine = StartCoroutine(CreateFiguresRoutine(_startingAmount, true));
        }

        

        private IEnumerator CreateFiguresRoutine(int amount, bool debug = false)
        {
            if (debug)
            {
                int figureTypeCount = Enum.GetValues(typeof(FigureType)).Length;
                int maxAvailableTypes = Mathf.Min(amount / 3, figureTypeCount); 

                List<FigureType> availableTypes = new List<FigureType>((FigureType[])Enum.GetValues(typeof(FigureType)));
                availableTypes = availableTypes.OrderBy(_ => UnityEngine.Random.value).Take(maxAvailableTypes).ToList();

                foreach (var type in availableTypes)
                {
                    Color color = GetRandomColor();
                    for (int i = 0; i < 3; i++)
                    {
                        _figureFactory.CreateFigure(type, color);
                        _currentAmount++;
                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }
            else
            {
                for (int i = 0; i < _currentAmount; i++)
                {
                    _figureFactory.CreateFigure();
                    yield return new WaitForSeconds(0.3f);
                }
            }
        }

        public void RegenerateFigures()
        {
            if (_createFiguresRoutine != null)
            {
                StopCoroutine(_createFiguresRoutine);
            }
            _figureFactory.DestroyFigures(); 
            _createFiguresRoutine = StartCoroutine(RegenerateFiguresRoutine(true));
        }

        public void MinusFigure()
        {
            _currentAmount -= 1;
            CheckGameCondition();
        }

        private void CheckGameCondition()
        {
            var usedCells = _scorePresenter.GetUsedCells();
            Debug.Log(_currentAmount);
            if (usedCells == 7)
            {
                OnGameConditionChanged(GameState.Lose);
                return;
            }
            else if (_currentAmount == 0)
            {
                OnGameConditionChanged(GameState.Win);
                return;
            } 
        }

        private IEnumerator RegenerateFiguresRoutine(bool debug = false)
        {
            if (debug)
            {
                int figureTypeCount = Enum.GetValues(typeof(FigureType)).Length;
                int maxAvailableTypes = Mathf.Min(_currentAmount / 3, figureTypeCount); 

                List<FigureType> availableTypes = new List<FigureType>((FigureType[])Enum.GetValues(typeof(FigureType)));
                availableTypes = availableTypes.OrderBy(_ => UnityEngine.Random.value).Take(maxAvailableTypes).ToList();

                foreach (var type in availableTypes)
                {
                    Color color = GetRandomColor();
                    for (int i = 0; i < 3; i++)
                    {
                        _figureFactory.CreateFigure(type, color);
                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }
            else
            {
                for (int i = 0; i < _currentAmount; i++)
                {
                    _figureFactory.CreateFigure();
                    yield return new WaitForSeconds(0.3f);
                }
            }
        }

        private Color GetRandomColor()
        {
            var colors = new []{Color.red, Color.green, Color.blue};
            return colors[UnityEngine.Random.Range(0, colors.Length)];
        }

        public void RestartGame()
        {
            _currentAmount = 0;
            _scorePresenter.ResetAllView();
            _figureFactory.DestroyFigures();
            CreateObjects();
        }
    }
}
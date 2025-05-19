using System.Collections;
using _Root.Code.Figure;
using UnityEngine;

namespace _Root.Code
{
    public class GameManager : MonoBehaviour
    {
        private Coroutine _createFiguresRoutine;
        public void CreateObjects(int amount, FigureFactory figureFactory)
        {
            if (_createFiguresRoutine != null)
            {
                StopCoroutine(_createFiguresRoutine);
            }

            _createFiguresRoutine = StartCoroutine(CreateFiguresRoutine(amount, figureFactory, true));
        }

        private IEnumerator CreateFiguresRoutine(int amount, FigureFactory figureFactory, bool debug = false)
        {
            if (debug)
            {
                int amountOfEach = amount / 3;
                for (int i = 0; i < amountOfEach; i++)
                {
                    figureFactory.CreateFigure(FigureType.Circle, Color.red);
                    yield return new WaitForSeconds(0.3f);
                }
                for (int i = 0; i < amountOfEach; i++)
                {
                    figureFactory.CreateFigure(FigureType.Square, Color.blue);
                    yield return new WaitForSeconds(0.3f);
                }
                for (int i = 0; i < amountOfEach; i++)
                {
                    figureFactory.CreateFigure(FigureType.Hexagon, Color.green);
                    yield return new WaitForSeconds(0.3f);
                }
            }
            else
            {
                for (int i = 0; i < amount; i++)
                {
                    figureFactory.CreateFigure();
                    yield return new WaitForSeconds(0.3f);
                }
            }
        }
    }
}
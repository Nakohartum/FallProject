using System.Linq;
using _Root.Code.Figure.View;
using UnityEngine;

namespace _Root.Code.ScoreFeature
{
    public class ScorePresenter
    {
        private ScoreView _view;

        public ScorePresenter(ScoreView view)
        {
            _view = view;
        }

        public FigureCellView GetFigureCellView()
        {
            return _view.FigureCellViews.FirstOrDefault(q => q.FigurePresenter == null);
        }

        public void CheckCells()
        {
            var cells = _view.FigureCellViews;
            
            for (int i = 0; i < cells.Length; i++)
            {
                var cell = cells[i];
                FigureCellView[] figureCellViews = new FigureCellView[3];
                var count = 0;
                figureCellViews[0] = cell;
                for (int j = i; j < cells.Length; j++)
                {
                    if (cells[j].FigurePresenter == null)
                    {
                        continue;
                    }
                    if (cell.FigurePresenter.CompareTo(cells[j].FigurePresenter) == 0)
                    {
                        figureCellViews[count++] = cells[j];
                        if (count == 3)
                        {
                            DestroyFigureCells(figureCellViews);
                            return;
                        }
                    }
                }
            }
        }

        private void DestroyFigureCells(FigureCellView[] figureCellViews)
        {
            for (int i = 0; i < figureCellViews.Length; i++)
            {
                figureCellViews[i].ResetView();
            }
        }
    }
}
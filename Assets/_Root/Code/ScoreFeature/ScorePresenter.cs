using System.Collections.Generic;
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
            var matchingGroup = FindMatchingGroup(_view.FigureCellViews);
            
            if (matchingGroup != null)
            {
                DestroyFigureCells(matchingGroup);
            }
        }

        public int GetUsedCells()
        {
            var result = 0;
            for (int i = 0; i < _view.FigureCellViews.Length; i++)
            {
                if (_view.FigureCellViews[i].FigurePresenter != null)
                {
                    result++;
                }
            }

            return result;
        }
        
        private FigureCellView[] FindMatchingGroup(FigureCellView[] cells)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                var basePresenter = cells[i].FigurePresenter;
                if (basePresenter == null) continue;

                var group = new List<FigureCellView> { cells[i] };

                for (int j = 0; j < cells.Length; j++)
                {
                    if (i == j) continue;

                    var current = cells[j].FigurePresenter;
                    if (current == null) continue;

                    if (basePresenter.CompareTo(current) == 0)
                    {
                        group.Add(cells[j]);
                        if (group.Count == 3)
                        {
                            return group.ToArray();
                        }
                    }
                }
            }

            return null;
        }

        private void DestroyFigureCells(FigureCellView[] figureCellViews)
        {
            for (int i = 0; i < figureCellViews.Length; i++)
            {
                figureCellViews[i].ResetView();
            }
        }
        
        

        public void ResetAllView()
        {
            for (int i = 0; i < _view.FigureCellViews.Length; i++)
            {
                _view.FigureCellViews[i].ResetView();
            }
        }
    }
}
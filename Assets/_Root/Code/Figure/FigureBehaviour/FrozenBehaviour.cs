using System;
using _Root.Code.Figure.View;
using UnityEngine;

namespace _Root.Code.Figure.FigureBehaviour
{
    public class FrozenBehaviour : IFigureBehaviour
    {
        private int _frozenCounter;
        public IFigureView View { get; }

        public FrozenBehaviour(IFigureView view, int frozenCounter = 3)
        {
            View = view;
            _frozenCounter = frozenCounter;
        }

        public void OnSpawn()
        {
            GameEventBus.Events.ItemClickedEvent.OnItemClicked += SetFrozenBehaviour;
        }

        private void SetFrozenBehaviour(float arg1)
        {
            
            if (arg1 >= _frozenCounter)
            {
                View.SetEnabled(true);
                View.FigurePresenter.FigureModel.ChangeColor();
                GameEventBus.Events.ItemClickedEvent.OnItemClicked -= SetFrozenBehaviour;
            }
        }

        public void OnUpdate()
        {
        }

        public void OnDestroy()
        {
            
        }
    }
}
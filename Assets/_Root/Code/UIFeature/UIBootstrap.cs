using System;
using UnityEngine;

namespace _Root.Code.UIFeature
{
    public class UIBootstrap : MonoBehaviour
    {
        [SerializeField] private UIView _view;
        [SerializeField] private GameManager _gameManager;

        public UIPresenter UIPresenter { get; private set; }
        
        public void Initialize()
        {
            UIPresenter = new UIPresenter(_view, _gameManager);
        }
    }
}
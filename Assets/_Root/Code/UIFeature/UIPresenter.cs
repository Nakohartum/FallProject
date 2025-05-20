using _Root.Code.ScoreFeature;

namespace _Root.Code.UIFeature
{
    public class UIPresenter
    {
        private UIView _view;
        private GameManager _gameManager;

        public UIPresenter(UIView view, GameManager gameManager)
        {
            _view = view;
            _gameManager = gameManager;
            _view.RegenerateButton.onClick.AddListener(_gameManager.RegenerateFigures);
            _gameManager.OnGameConditionChanged += ConditionChanged;
            _view.RestartButton.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            HideLoseScreen();
            HideWinScreen();
            HideRestartButton();
            _gameManager.RestartGame();
        }

        private void ConditionChanged(GameState obj)
        {
            if (obj == GameState.Win)
            {
                HideLoseScreen();
                OpenWinScreen();
                ShowRestartButton();
            }
            else if (obj == GameState.Lose)
            {
                HideWinScreen();
                OpenLoseScreen();
                ShowRestartButton();
            }
        }

        private void HideRestartButton()
        {
            _view.RestartButton.gameObject.SetActive(false);
        }

        private void ShowRestartButton()
        {
            _view.RestartButton.gameObject.SetActive(true);
        }

        public void OpenWinScreen()
        {
            _view.WinScreen.SetActive(true);
        }

        public void HideWinScreen()
        {
            _view.WinScreen.SetActive(false);
        }

        public void OpenLoseScreen()
        {
            _view.LoseScreen.SetActive(true);
        }

        public void HideLoseScreen()
        {
            _view.LoseScreen.SetActive(false);
        }
    }
}
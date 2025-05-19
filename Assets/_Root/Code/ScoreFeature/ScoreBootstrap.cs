using UnityEngine;

namespace _Root.Code.ScoreFeature
{
    public class ScoreBootstrap : MonoBehaviour
    {
        [SerializeField] private ScoreView _scoreView;
        
        public ScorePresenter ScorePresenter { get; private set; }

        public void Initialize()
        {
            ScorePresenter = new ScorePresenter(_scoreView);
        }
    }
}
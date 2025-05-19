using _Root.Code.EditorHelper;
using _Root.Code.Figure.View;
using _Root.Code.ScoreFeature;
using UnityEngine;

namespace _Root.Code.Figure
{
    public class FigureBootstrap : MonoBehaviour
    {
        
        [SerializeField] private FigureView _figureViewPrefab;
        [SerializeField] private FigureCellView _figureCellViewPrefab;
        [SerializeField] private Transform _parentForCells;
        [SerializeField] private Color[] _colors;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private SpriteToEnum<FigureType>[] _backgroundSprites;
        
        public FigureFactory FigureFactory { get; private set; }
        public FigureCellFactory FigureCellFactory { get; private set; }

        public void Initialize(float thickness, ScorePresenter scorePresenter)
        {
            FigureCellFactory = new FigureCellFactory();
            FigureFactory = new FigureFactory(_sprites, _colors, _figureViewPrefab, _backgroundSprites, thickness, FigureCellFactory, scorePresenter);
        }
    }
}
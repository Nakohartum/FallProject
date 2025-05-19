using System.Linq;
using _Root.Code.Figure.View;
using UnityEngine;

namespace _Root.Code.ScoreFeature
{
    public class ScoreView : MonoBehaviour
    {
        [field: SerializeField] public FigureCellView[] FigureCellViews { get; private set; }
        
    }
}
using _Root.Code.Figure.View;

namespace _Root.Code.Figure.FigureBehaviour
{
    public interface IFigureBehaviour
    {
        IFigureView View { get; }
        void OnSpawn();
        void OnUpdate();
        void OnDestroy();
    }
}
using _Root.Code.Figure.View;

namespace _Root.Code.Figure.FigureBehaviour
{
    public class HeavyBehaviour : IFigureBehaviour
    {
        private float _mass;
        public IFigureView View { get; }

        public HeavyBehaviour(IFigureView view, float mass = 4f)
        {
            _mass = mass;
            View = view;
        }

        

        public void OnSpawn()
        {
            View.Rigidbody2D.mass = _mass;
        }

        public void OnUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnDestroy()
        {
            throw new System.NotImplementedException();
        }
    }
}
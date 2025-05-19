using _Root.Code.Figure.View;
using UnityEngine;

namespace _Root.Code.InputFeature
{
    public class InputHandler
    {
        public void Execute()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Collider2D hit = Physics2D.OverlapPoint(worldPos);

                if (hit && hit.TryGetComponent(out FigureView figure))
                {
                    figure.PerformClick();
                }
            }
        }
    }
}
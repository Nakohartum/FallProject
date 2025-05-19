using UnityEngine;

namespace _Root.Code.ClampFeature
{
    public class ScreenBoundsCollider
    {
        private readonly float _thickness;

        public ScreenBoundsCollider(float thickness)
        {
            _thickness = thickness;
        }
    
        public void CreateColliders()
        {
            Camera cam = Camera.main;
            Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
            Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            
            CreateCollider("Left", new Vector2(bottomLeft.x , 0), new Vector2(_thickness, topRight.y * 2));
            CreateCollider("Right", new Vector2(topRight.x, 0), new Vector2(_thickness, topRight.y * 2));
            CreateCollider("Bottom", new Vector2(0, bottomLeft.y + 1), new Vector2(topRight.x * 2, _thickness));
        }

        private void CreateCollider(string goName, Vector2 position, Vector2 size)
        {
            GameObject go = new GameObject(goName)
            {
                transform =
                {
                    position = position
                }
            };
            var boxCollider2D = go.AddComponent<BoxCollider2D>();
            boxCollider2D.size = size;
            boxCollider2D.isTrigger = false;
        }
    }
}
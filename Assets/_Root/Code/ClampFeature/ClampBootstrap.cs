using UnityEngine;

namespace _Root.Code.ClampFeature
{
    public class ClampBootstrap : MonoBehaviour
    {
        [field: SerializeField] public float Thickness { get; private set; }
        
        [field: SerializeField] public ScreenBoundsCollider ScreenBoundsCollider { get; private set; }

        public void Initialize()
        {
            ScreenBoundsCollider = new ScreenBoundsCollider(Thickness);
            ScreenBoundsCollider.CreateColliders();
        }
    }
}
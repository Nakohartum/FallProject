using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.UIFeature
{
    public class UIView : MonoBehaviour
    {
        [field: SerializeField] public Button RegenerateButton { get; private set; }
        [field: SerializeField] public GameObject WinScreen { get; private set; }
        [field: SerializeField] public GameObject LoseScreen { get; private set; }
        [field: SerializeField] public Button RestartButton { get; private set; }
    }
}
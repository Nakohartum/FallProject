using System;
using UnityEngine;

namespace _Root.Code.EditorHelper
{
    [Serializable]
    public class SpriteToEnum<T> where T : Enum
    {
        public T Type;
        public Sprite Sprite;
    }
}
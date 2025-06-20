using System;
using _Root.Code.Figure.View;
using UnityEngine;

namespace _Root.Code
{
    public static class GameEventBus
    {
        

        public static void CallOnItemClicked()
        {
            Events.ItemClickedEvent.AddCounter();
            Events.ItemClickedEvent.InvokeEvent();
        }
        public static class Events
        {
            public static class ItemClickedEvent
            {
                private static int _figuresCounter;
                public static event Action<float> OnItemClicked = delegate { };
                public static void ResetCounter() => _figuresCounter = 0;
                public static void AddCounter() => _figuresCounter++;
                public static void InvokeEvent() => OnItemClicked?.Invoke(_figuresCounter);
            }
        }
    }

    
}
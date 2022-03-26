using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DiceGame
{
    public class DiceClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public event Action Clicked;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (enabled == false) return;
            Clicked?.Invoke();
        }
    }
}


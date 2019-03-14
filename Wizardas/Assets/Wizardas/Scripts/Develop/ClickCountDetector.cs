using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.EventSystems;

namespace EllGames
{
    public class ClickCountDetector : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            int clickCount = eventData.clickCount;

            if (clickCount == 1)
                OnSingleClick();
            else if (clickCount == 2)
                OnDoubleClick();
            else if (clickCount > 2)
                OnMultiClick();
        }

        void OnSingleClick()
        {
            Debug.Log("Single Clicked");
        }

        void OnDoubleClick()
        {
            Debug.Log("Double Clicked");
        }

        void OnMultiClick()
        {
            Debug.Log("MultiClick Clicked");
        }
    }
}


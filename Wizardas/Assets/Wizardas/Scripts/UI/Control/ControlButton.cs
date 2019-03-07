using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.EventSystems;

namespace EllGames.Wiz.UI.Control
{
    public class ControlButton : ControlComponent, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [Title("Required")]
        [OdinSerialize, Required] Hud.HudOverlay m_HoverOverlay;
        [OdinSerialize, Required] Hud.HudOverlay m_PressOverlay;

        [Title("Settings")]
        [OdinSerialize] UnityEvent m_OnClick = new UnityEvent();

	    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            m_HoverOverlay.EnableSmoothly();
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            m_HoverOverlay.DisableSmoothly();
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            m_PressOverlay.EnableSmoothly();
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            m_PressOverlay.DisableSmoothly();
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            m_OnClick.Invoke();
        }
    }
}

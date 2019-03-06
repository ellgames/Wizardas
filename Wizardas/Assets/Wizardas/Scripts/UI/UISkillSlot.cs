using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.EventSystems;

namespace EllGames.Wiz.UI
{
    public class UISkillSlot : UIComponent, IPointerEnterHandler, IPointerExitHandler
    {
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            m_HudSkillTooltip.Assign(m_ISkillInfoWatch);
            m_HudSkillTooltip.gameObject.SetActive(true);
            m_HoverOverlay.gameObject.SetActive(true);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            m_HudSkillTooltip.gameObject.SetActive(false);
            m_HoverOverlay.gameObject.SetActive(false);
        }

        [Title("Required")]
        [OdinSerialize, Required] ICoolTimeWatch m_ICoolTimeWatch;
        [OdinSerialize, Required] ISkillInfoWatch m_ISkillInfoWatch;

        [Title("UI Reference")]
        [OdinSerialize] Image m_IconImage;
        [OdinSerialize] Image m_CoolTimeFillImage;
        [OdinSerialize] Image m_HoverOverlay;
        [OdinSerialize] Text m_HotkeyText;
        [OdinSerialize] Hud.HudSkillTooltip m_HudSkillTooltip;

        private void Update()
        {
            m_IconImage.sprite = m_ISkillInfoWatch.SkillIcon();
            m_CoolTimeFillImage.fillAmount = m_ICoolTimeWatch.CoolTimeRemain() / m_ICoolTimeWatch.CoolTime();
        }
    }
}

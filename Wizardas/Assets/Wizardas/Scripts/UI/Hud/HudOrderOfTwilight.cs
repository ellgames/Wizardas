using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine.EventSystems;

namespace EllGames.Wiz.UI.Hud
{
    public class HudOrderOfTwilight : HudComponent, IPointerEnterHandler, IPointerExitHandler
    {
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            var label = "";
            var description = "";

            switch (m_SystemProfile.Language)
            {
                case Meta.LANGUAGE.Japanese:
                    label = m_Label_Jpn;
                    description = m_Description_Jpn;
                    if (m_Unlocked) label += m_Unlocked_Jpn;
                    break;
                case Meta.LANGUAGE.English:
                    label = m_Label_Eng;
                    description = m_Description_Eng;
                    if (m_Unlocked) label += m_Unlocked_Eng;
                    break;
            }

            m_HudOrderTooltip.Assign(label, description);
            m_HudOrderTooltip.gameObject.SetActive(true);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            m_HudOrderTooltip.gameObject.SetActive(false);
        }

        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;
        [OdinSerialize, Required] HudOrderTooltip m_HudOrderTooltip;
        [OdinSerialize, Required] GameObject m_Overlay;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_FF_MA;

        [Title("Settings")]
        [OdinSerialize] string m_Label_Jpn;
        [OdinSerialize] string m_Label_Eng;
        [OdinSerialize] string m_Description_Jpn;
        [OdinSerialize] string m_Description_Eng;
        [OdinSerialize] string m_Unlocked_Jpn;
        [OdinSerialize] string m_Unlocked_Eng;
        [OdinSerialize] int m_Constraint;

        bool m_Unlocked;

        private void Update()
        {
            if (m_HighScoreProfile_FF_MA.Score >= m_Constraint)
            {
                m_Overlay.gameObject.SetActive(false);
                m_Unlocked = true;
            }
            else
            {
                m_Overlay.gameObject.SetActive(true);
                m_Unlocked = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI.Hud
{
    [RequireComponent(typeof(Text))]
    public class HudCountDownText : HudComponent
    {
        [Title("Required")]
        [OdinSerialize] Utility.Timer m_Timer;

        [Title("Settings")]
        [OdinSerialize] bool m_Fading = true;
        [OdinSerialize] int m_StartFontSize;
        [OdinSerialize] int m_EndFontSize;

        Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();    
        }

        private void Update()
        {
            m_Text.text = ((int)m_Timer.Seconds).ToString();
            m_Text.fontSize = (int)Mathf.Lerp(m_StartFontSize, m_EndFontSize, 1f - (m_Timer.Seconds - (int)m_Timer.Seconds));

            if (m_Fading)
            {
                var currentColor = m_Text.color;
                currentColor.a = m_Timer.Seconds - (int)m_Timer.Seconds;
                m_Text.color = currentColor;
            }
        }
    }
}

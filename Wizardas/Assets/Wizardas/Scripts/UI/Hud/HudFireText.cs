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
    public class HudFireText : HudComponent
    {
        [Title("Settings")]
        [OdinSerialize] float m_Duration = 1f;
        [OdinSerialize] int m_StartFontSize;
        [OdinSerialize] int m_EndFontSize;

        Text m_Text;
        float m_TimeElapsed;

        private void Awake()
        {
            m_Text = GetComponent<Text>();
        }

        private void Update()
        {
            /* シンプルにフェードアウトしていくパターン*/
            /*
            m_TimeElapsed += Time.deltaTime;

            var currentColor = m_Text.color;
            currentColor.a = 1f - m_TimeElapsed / m_Duration;
            m_Text.color = currentColor;

            m_Text.fontSize = (int)Mathf.Lerp(m_StartFontSize, m_EndFontSize, m_TimeElapsed / m_Duration);
            */

            m_TimeElapsed += Time.deltaTime;

            if (m_TimeElapsed >= m_Duration / 2)
            {
                var currentColor = m_Text.color;
                currentColor.a = 1f - m_TimeElapsed / m_Duration;
                m_Text.color = currentColor;

                m_Text.fontSize = (int)Mathf.Lerp(m_StartFontSize, m_EndFontSize, ((m_TimeElapsed - m_Duration / 2) * 2) / m_Duration);
            }
            
        }
    }
}

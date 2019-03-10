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
    public class HudScoreText : HudComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.ScoreProfile m_ScoreProfile;
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;

        [Title("Settings")]
        [OdinSerialize] string m_Unit_Jpn = "ポイント";
        [OdinSerialize] string m_Unit_Eng = "Points";

        Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();
        }

        private void Update()
        {
            Debug.Assert(m_Text != null);
            Debug.Assert(m_ScoreProfile != null);
            Debug.Assert(m_SystemProfile != null);

            switch (m_SystemProfile.Language)
            {
                case Meta.LANGUAGE.Japanese:
                    m_Text.text = m_ScoreProfile.Score.ToString("N0") + " " + m_Unit_Jpn;
                    break;
                case Meta.LANGUAGE.English:
                    m_Text.text = m_ScoreProfile.Score.ToString("N0") + " " + m_Unit_Eng;
                    break;
            }
        }
    }
}

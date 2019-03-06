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

        Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();
        }

        private void Update()
        {
            Debug.Assert(m_Text != null);
            Debug.Assert(m_ScoreProfile != null);

            m_Text.text = m_ScoreProfile.Score.ToString("N0");
        }
    }
}

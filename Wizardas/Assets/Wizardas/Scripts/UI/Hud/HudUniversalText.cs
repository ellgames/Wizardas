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
    public class HudUniversalText : HudComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;

        [Title("Settings")]
        [OdinSerialize, TextArea(1, 20)] string m_TextEng = "Text";
        [OdinSerialize, TextArea(1, 20)] string m_TextJpn = "テキスト";

        Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();

            switch (m_SystemProfile.Language)
            {
                case Meta.LANGUAGE.English:
                    m_Text.text = m_TextEng;
                    break;
                case Meta.LANGUAGE.Japanese:
                    m_Text.text = m_TextJpn;
                    break;
            }
        }
    }
}

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
    public class HudRecordText : HudComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;
        [OdinSerialize, Required] Profile.KillProfile m_KillProfile;

        [OdinSerialize] string m_KillCount_Jpn = "討伐数";
        [OdinSerialize] string m_KillCount_Eng = "Killed Count";

        Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();

            var name1 = "Weak Ghoul";
            var name2 = "Weak Undead Ent";
            var name3 = "Ghoul";
            var name4 = "Undead Ent";
            var name5 = "Succubus Mage";
            var name6 = "Strong Ghoul";
            var name7 = "Strong Undead Ent";
            var name8 = "Strong Succubus Mage";

            var line1 = name1 + " ";
            var line2 = name2 + " ";
            var line3 = name3 + " ";
            var line4 = name4 + " ";
            var line5 = name5 + " ";
            var line6 = name6 + " ";
            var line7 = name7 + " ";
            var line8 = name8 + " ";

            switch (m_SystemProfile.Language)
            {
                case Meta.LANGUAGE.English:
                    line1 += m_KillCount_Eng;
                    line2 += m_KillCount_Eng;
                    line3 += m_KillCount_Eng;
                    line4 += m_KillCount_Eng;
                    line5 += m_KillCount_Eng;
                    line6 += m_KillCount_Eng;
                    line7 += m_KillCount_Eng;
                    line8 += m_KillCount_Eng;
                    break;
                case Meta.LANGUAGE.Japanese:
                    line1 += m_KillCount_Jpn;
                    line2 += m_KillCount_Jpn;
                    line3 += m_KillCount_Jpn;
                    line4 += m_KillCount_Jpn;
                    line5 += m_KillCount_Jpn;
                    line6 += m_KillCount_Jpn;
                    line7 += m_KillCount_Jpn;
                    line8 += m_KillCount_Jpn;
                    break;
            }

            line1 += " = " + m_KillProfile.KillCount_WeakGhoul;
            line2 += " = " + m_KillProfile.KillCount_WeakUndeadEnt;
            line3 += " = " + m_KillProfile.KillCount_Ghoul;
            line4 += " = " + m_KillProfile.KillCount_UndeadEnt;
            line5 += " = " + m_KillProfile.KillCount_SuccubusMage;
            line6 += " = " + m_KillProfile.KillCount_StrongGhoul;
            line7 += " = " + m_KillProfile.KillCount_StrongUndeadEnt;
            line8 += " = " + m_KillProfile.KillCount_StrongSuccubusMage;

            m_Text.text = "";
            m_Text.text += line1 + "\n";
            m_Text.text += line2 + "\n";
            m_Text.text += line3 + "\n";
            m_Text.text += line4 + "\n";
            m_Text.text += line5 + "\n";
            m_Text.text += line6 + "\n";
            m_Text.text += line7 + "\n";
            m_Text.text += line8;
        }
    }
}

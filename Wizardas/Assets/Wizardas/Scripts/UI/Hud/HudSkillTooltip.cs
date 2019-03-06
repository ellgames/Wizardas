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
    public class HudSkillTooltip : HudComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;

        [Title("UI Reference")]
        [OdinSerialize] Image m_SkillIconImage;
        [OdinSerialize] Text m_SkillNameText;
        [OdinSerialize] Text m_DescriptionText;
        [OdinSerialize] Text m_UsingTimeText;
        [OdinSerialize] Text m_CoolTimeText;
         
        void Apply(Sprite skillIcon, string skillName, string description, float usingTime, float coolTime)
        {
            m_SkillIconImage.sprite = skillIcon;
            m_SkillNameText.text = skillName;
            m_DescriptionText.text = description;

            string m_UsingTimeString = "";
            string m_CoolTimeString = "";
            string m_SecString = "";

            switch (m_SystemProfile.Language)
            {
                case Meta.LANGUAGE.Japanese:
                    m_UsingTimeString = "使用時間";
                    m_CoolTimeString = "クールタイム";
                    m_SecString = "秒";
                    break;
                case Meta.LANGUAGE.English:
                    m_UsingTimeString = "Using Time";
                    m_CoolTimeString = "Cool Time";
                    m_SecString = "Sec";
                    break;
            }

            m_UsingTimeText.text = m_UsingTimeString + " : " + usingTime.ToString("N1") + " " + m_SecString;
            m_CoolTimeText.text = m_CoolTimeString + " : " + usingTime.ToString("N1") + " " + m_SecString;
        }

        public void Unassign()
        {
            Apply(null, null, null, 0.0f, 0.0f);
        }

        public void Assign(ISkillInfoWatch iSkillInfoWatch)
        {
            Apply(iSkillInfoWatch.SkillIcon(), iSkillInfoWatch.SkillName(), iSkillInfoWatch.Description(), iSkillInfoWatch.UsingTime(), iSkillInfoWatch.CoolTime());
        }
    }
}

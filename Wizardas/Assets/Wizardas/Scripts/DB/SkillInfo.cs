﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.DB
{
    [CreateAssetMenu(menuName = "DB/SkillInfo", fileName = "SkillInfo")]
    public class SkillInfo : SerializedScriptableObject, UI.ISkillInfoWatch
    {
        Sprite UI.ISkillInfoWatch.SkillIcon()
        {
            return m_Icon;
        }

        float UI.ISkillInfoWatch.UsingTime()
        {
            return m_UsingTimeSec;
        }

        float UI.ISkillInfoWatch.CoolTime()
        {
            return m_CoolTimeSec;
        }

        string UI.ISkillInfoWatch.Description()
        {
            return Description();
        }

        string UI.ISkillInfoWatch.SkillName()
        {
            return SkillName();
        }

        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;

        [Title("UI")]
        [OdinSerialize, PreviewField] Sprite m_Icon;

        [Title("Meta")]
        [OdinSerialize] string m_SkillIdentifier;
        public string SkillIdentifier
        {
            get { return m_SkillIdentifier; }
        }

        [Title("Basic")]
        [OdinSerialize] string m_SkillName_Jpn;
        public string SkillName_Jpn
        {
            get { return m_SkillName_Jpn; }
        }

        [OdinSerialize] string m_SkillName_Eng;
        public string SkillName_Eng
        {
            get { return m_SkillName_Eng; }
        }

        [OdinSerialize] string m_Description_Jpn;
        public string Description_Jpn
        {
            get { return m_Description_Jpn; }
        }

        [OdinSerialize] string m_Description_Eng;
        public string Description_Eng
        {
            get { return m_Description_Eng; }
        }

        [Title("Spec")]
        [OdinSerialize] float m_UsingTimeSec = 0f;
        public float UsingTimeSec
        {
            get { return m_UsingTimeSec; }
        }

        [OdinSerialize] float m_CoolTimeSec = 0f;
        public float CoolTimeSec
        {
            get { return m_CoolTimeSec; }
        }

        public string SkillName()
        {
            switch (m_SystemProfile.Language)
            {
                default:
                    return null;
                case Meta.LANGUAGE.Japanese:
                    return m_SkillName_Jpn;
                case Meta.LANGUAGE.English:
                    return m_SkillName_Eng;
            }
        }

        public string Description()
        {
            switch (m_SystemProfile.Language)
            {
                default:
                    return null;
                case Meta.LANGUAGE.Japanese:
                    return m_Description_Jpn;
                case Meta.LANGUAGE.English:
                    return m_Description_Eng;
            }
        }

        [Title("Developper")]
        [OdinSerialize, TextArea(3, 5)] string m_Memo;
    }
}
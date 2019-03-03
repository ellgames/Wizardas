using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Actor.PlayerBehaviour
{
    public abstract class UseSkillCommandBase : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] DB.SkillInfo m_SkillInfo;
        public DB.SkillInfo SkillInfo
        {
            get { return m_SkillInfo; }
        }

        [Title("State")]
        [OdinSerialize] float m_UsingTimeRemain;
        public float UsingTimeRemain
        {
            get { return m_UsingTimeRemain; }
        }

        [OdinSerialize] float m_CoolTimeRemain;
        public float CoolTimeRemain
        {
            get { return m_CoolTimeRemain; }
        }

        public virtual void Execute()
        {
            m_UsingTimeRemain = m_SkillInfo.UsingTimeSec;
            m_CoolTimeRemain = m_SkillInfo.CoolTimeSec;
        }

        private void Update()
        {
            m_UsingTimeRemain -= Time.deltaTime;
            m_CoolTimeRemain -= Time.deltaTime;

            if (m_UsingTimeRemain < 0f) m_UsingTimeRemain = 0f;
            if (m_CoolTimeRemain < 0f) m_CoolTimeRemain = 0f;
        }
    }
}

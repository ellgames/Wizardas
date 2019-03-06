using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.InputManagement
{
    public class PlayerInputHandler : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Config.KeyConfig m_KeyConfig;
        [OdinSerialize, Required] GameSystem.Actor.PlayerBehaviour.PlayerBehaviourHandler m_PlayerBehaviourHandler;

        [Title("Skill Infos")]
        [OdinSerialize] DB.SkillInfo m_SkillInfo_Jump;
        [OdinSerialize] DB.SkillInfo m_SkillInfo_StandardAttack;
        [OdinSerialize] DB.SkillInfo m_SkillInfo_HellFire;
        [OdinSerialize] DB.SkillInfo m_SkillInfo_HellFlameFissure;
        [OdinSerialize] DB.SkillInfo m_SkillInfo_HellArea;

        private void Update()
        {
            if (Input.GetKey(m_KeyConfig.JumpKey))
            {
                m_PlayerBehaviourHandler.UseSkill(m_SkillInfo_Jump.SkillIdentifier);
            }

            if (Input.GetKey(m_KeyConfig.Skill1Key))
            {
                m_PlayerBehaviourHandler.UseSkill(m_SkillInfo_StandardAttack.SkillIdentifier);
            }

            if (Input.GetKey(m_KeyConfig.Skill2Key))
            {
                m_PlayerBehaviourHandler.UseSkill(m_SkillInfo_HellFire.SkillIdentifier);
            }

            if (Input.GetKey(m_KeyConfig.Skill3Key))
            {
                m_PlayerBehaviourHandler.UseSkill(m_SkillInfo_HellFlameFissure.SkillIdentifier);
            }

            if (Input.GetKey(m_KeyConfig.Skill4Key))
            {
                m_PlayerBehaviourHandler.UseSkill(m_SkillInfo_HellArea.SkillIdentifier);
            }
        }
    }
}

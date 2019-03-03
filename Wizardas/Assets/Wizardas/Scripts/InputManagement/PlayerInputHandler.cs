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
        [OdinSerialize, Required] DB.SkillInfo m_SkillInfo_Jump;

        private void Update()
        {
            if (Input.GetKeyDown(m_KeyConfig.JumpKey))
            {
                m_PlayerBehaviourHandler.UseSkill(m_SkillInfo_Jump.SkillIdentifier);
            }
        }
    }
}

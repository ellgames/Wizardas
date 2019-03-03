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
    public class PlayerBehaviourHandler : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] PlayerMove m_PlayerMove;
        [OdinSerialize, Required] SkillManager m_SkillManager;
        [OdinSerialize, Required] Die m_Die;

	    public void UseSkill(string skillIdentifier)
        {
            m_SkillManager.UseSkill(skillIdentifier);
        }

        public void AllowMove()
        {
            m_PlayerMove.AllowMove();
        }

        public void DisallowMove()
        {
            m_PlayerMove.DisallowMove();
        }

        public void AllowSkillUse()
        {
            m_SkillManager.AllowSkillUse();
        }

        public void DisallowSkillUse()
        {
            m_SkillManager.DisallowSkillUse();
        }

        public void Kill()
        {
            m_Die.gameObject.SetActive(true);
            DisallowMove();
            DisallowSkillUse();
        }
    }
}

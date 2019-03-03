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

        public void Kill()
        {

        }
    }
}

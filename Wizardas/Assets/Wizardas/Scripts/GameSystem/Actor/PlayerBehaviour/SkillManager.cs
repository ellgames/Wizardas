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
    public class SkillManager : SerializedMonoBehaviour, ISkillUseWatch
    {
        bool ISkillUseWatch.SkillUsing()
        {
            foreach(var command in m_UseSkillCommands)
            {
                if (command.UsingTimeRemain > 0f) return true;
            }

            return false;
        }

        [Title("Required")]
        [OdinSerialize, Required] IDeadWatch m_IDeadWatch;
        [OdinSerialize, Required] List<UseSkillCommandBase> m_UseSkillCommands = new List<UseSkillCommandBase>();

        [Title("State")]
        [OdinSerialize] bool m_SkillUseIsAllowed = true;

        public void AllowSkillUse()
        {
            m_SkillUseIsAllowed = true;
        }

        public void DisallowSkillUse()
        {
            m_SkillUseIsAllowed = false;
        }

        UseSkillCommandBase SearchUseSkillCommand(string skillIdentifier)
        {
            UseSkillCommandBase found = null;

            m_UseSkillCommands.ForEach(command =>
            {
                if (command.SkillInfo.SkillIdentifier == skillIdentifier) found = command;
            });

            return found;
        }

        bool CanUseSkill(UseSkillCommandBase target)
        {
            Debug.Assert(target != null);

            if (!m_SkillUseIsAllowed) return false;
            if (m_IDeadWatch.IsDead()) return false;
            if (target.CoolTimeRemain > 0f) return false;

            foreach (UseSkillCommandBase command in m_UseSkillCommands)
            {
                if (command.UsingTimeRemain > 0f) return false;
            }

            return true;
        }

        /// <summary>
        /// スキルを使用します。
        /// </summary>
        /// <param name="skillIdentifier"></param>
        /// <returns>スキルの使用に成功した場合はtrueを、失敗した場合はfalseを返します。</returns>
	    public bool UseSkill(string skillIdentifier)
        {
            var target = SearchUseSkillCommand(skillIdentifier);

            if (target == null) return false;
            if (!CanUseSkill(target)) return false;

            target.Execute();

            return true;
        }
    }
}

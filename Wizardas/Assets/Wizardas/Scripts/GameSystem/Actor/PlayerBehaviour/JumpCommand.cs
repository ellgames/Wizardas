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
    public class JumpCommand : UseSkillCommandBase
    {
        [Title("Required")]
        [OdinSerialize, Required] Rigidbody m_Rigidbody;

        [Title("Settings")]
        [OdinSerialize] float m_AddingForce = 20f;
        [OdinSerialize] Vector3 m_JumpDirection = Vector3.up;

        [Title("Advanced Settings")]
        [OdinSerialize] ForceMode m_ForceMode = ForceMode.VelocityChange;

        [Title("SE")]
        [Title("Animation")]

        public override void Execute()
        {
            base.Execute();

            Debug.Assert(m_Rigidbody != null);

            m_Rigidbody.AddForce(m_JumpDirection * m_AddingForce, m_ForceMode);
        }
    }
}

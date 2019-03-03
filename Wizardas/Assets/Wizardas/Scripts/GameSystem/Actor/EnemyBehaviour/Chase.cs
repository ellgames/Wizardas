using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Actor.EnemyBehaviour
{
    public class Chase : EnemyBehaviourBase
    {
        [Title("Required")]
        [OdinSerialize, Required] NavMeshAgent m_NavMeshAgent;
        [OdinSerialize, Required] Transform m_Target;

        [Title("Animation")]
        [OdinSerialize, Required] Animator m_Animator;
        [OdinSerialize] string m_ChaseAnimationName;

        protected override void OnEnable()
        {
            base.OnEnable();

            m_Animator.SetBool(m_ChaseAnimationName, true);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            m_NavMeshAgent.destination = transform.position;
            m_Animator.SetBool(m_ChaseAnimationName, false);
        }

        protected override void Update()
        {
            base.Update();

            m_NavMeshAgent.destination = m_Target.position;
        }
    }
}

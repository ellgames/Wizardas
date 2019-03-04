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

        [Title("Settings")]
        [OdinSerialize] Transform m_Target;
        public Transform Target
        {
            set { m_Target = value; }
        }

        [Title("Animation")]
        [OdinSerialize, Required] Animator m_Animator;
        [OdinSerialize] string m_ChaseAnimationName;

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            m_Animator.SetBool(m_ChaseAnimationName, false);
            m_NavMeshAgent.destination = m_NavMeshAgent.transform.position;
        }

        protected override void Update()
        {
            base.Update();

            if (m_Target != null)
            {
                m_NavMeshAgent.destination = m_Target.position;
                m_Animator.SetBool(m_ChaseAnimationName, true);
            }
            else
            {
                m_NavMeshAgent.destination = m_NavMeshAgent.transform.position;
                m_Animator.SetBool(m_ChaseAnimationName, false);
            }
        }
    }
}

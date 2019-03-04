using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Actor
{
    public class EnemyUpdater : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] IDeadWatch m_IDeadWatch;
        [OdinSerialize, Required] EnemyBehaviour.EnemyBehaviourHandler m_EnemyBehaviourHandler;
        [OdinSerialize, Required] NavMeshAgent m_NavMeshAgent;
        [OdinSerialize, Required] DB.Status m_Status;
        [OdinSerialize, Required] AI.ChaseAI m_ChaseAI;

        bool m_HasKilled = false;

        private void Update()
        {
            Debug.Assert(m_NavMeshAgent != null);
            Debug.Assert(m_Status != null);
            m_NavMeshAgent.speed = m_Status.RunSpeed;
            m_NavMeshAgent.stoppingDistance = m_Status.StoppingDistance;

            Debug.Assert(m_ChaseAI != null);
            m_ChaseAI.AttackDistance = m_Status.AttackDistance;

            Debug.Assert(m_IDeadWatch != null);
            if (m_IDeadWatch.IsDead())
            {
                if (m_HasKilled == false)
                {
                    m_EnemyBehaviourHandler.Kill();
                    m_HasKilled = true;
                }
            }
            else
            {
                m_HasKilled = false;
            }
        }
    }
}

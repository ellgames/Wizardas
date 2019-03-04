using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Actor.AI
{
    public class ChaseAI : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] EnemyBehaviour.EnemyBehaviourHandler m_EnemyBehaviourHandler;

        [Title("Chased")]
        [OdinSerialize] bool m_AutoFindOnEnable = true;
        [OdinSerialize, EnableIf("m_AutoFindOnEnable")] string m_ChasedTag = "Player";
        [OdinSerialize, DisableIf("m_AutoFindOnEnable")] Transform m_Chased;

        [Title("Settings")]
        [OdinSerialize] float m_AttackCoolTime = 1f;
        [OdinSerialize] float m_AttackDistance = 2.5f;
        public float AttackDistance
        {
            set { m_AttackDistance = value; }
        }

        float m_AttackCoolTimeDuration;

        [Button("Find Chased")]
        void FindChased()
        {
            m_Chased = GameObject.FindGameObjectWithTag(m_ChasedTag).transform;
        }

        private void OnEnable()
        {
            if (m_AutoFindOnEnable) FindChased();
        }

        private void Update()
        {
            m_AttackCoolTimeDuration -= Time.deltaTime;
            if (m_AttackCoolTimeDuration <= 0f) m_AttackCoolTimeDuration = 0f;

            m_EnemyBehaviourHandler.SetChased(m_Chased);

            if (m_Chased == null) return;

            if (Vector3.Distance(transform.position, m_Chased.position) <= m_AttackDistance)
            {
                if (m_AttackCoolTimeDuration == 0f)
                {
                    m_EnemyBehaviourHandler.LookAtPlayer();
                    m_EnemyBehaviourHandler.DisallowMove();
                    m_EnemyBehaviourHandler.Attack();
                    m_AttackCoolTimeDuration = m_AttackCoolTime;
                }
                else
                {
                    m_EnemyBehaviourHandler.LookAtPlayer();
                }
            }
            else
            {
                m_EnemyBehaviourHandler.AllowMove();
            }
        }
    }
}

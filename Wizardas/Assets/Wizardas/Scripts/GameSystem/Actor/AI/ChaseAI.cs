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
        [OdinSerialize] float m_AttackDistance = 2.5f;
        public float AttackDistance
        {
            set { m_AttackDistance = value; }
        }

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
            m_EnemyBehaviourHandler.SetChased(m_Chased);

            if (m_Chased == null) return;

            if (Vector3.Distance(transform.position, m_Chased.position) <= m_AttackDistance)
            {
                m_EnemyBehaviourHandler.DisallowMove();
                m_EnemyBehaviourHandler.LookAtPlayer();
                m_EnemyBehaviourHandler.Attack();
            }
            else
            {
                m_EnemyBehaviourHandler.AllowMove();
            }
        }
    }
}

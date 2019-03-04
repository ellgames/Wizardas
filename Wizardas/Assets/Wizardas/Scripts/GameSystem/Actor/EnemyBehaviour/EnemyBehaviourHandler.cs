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
    public class EnemyBehaviourHandler : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Chase m_Chase;
        [OdinSerialize, Required] Attack m_Attack;
        [OdinSerialize, Required] Die m_Die;
        [OdinSerialize, Required] LookAtPlayer m_LookAtPlayer;

        public void SetChased(Transform chased)
        {
            m_Chase.Target = chased;
        }

        [Button("Allow Move")]
        public void AllowMove()
        {
            if (m_Die.gameObject.activeSelf) return;
            if (m_Attack.gameObject.activeSelf) return;
            m_Chase.Activate();
        }

        [Button("Disllow Move")]
        public void DisallowMove()
        {
            m_Chase.Deactivate();
        }

        [Button("Attack")]
        public void Attack()
        {
            if (m_Die.gameObject.activeSelf) return;
            DisallowMove();
            m_Attack.Activate();
        }

        [Button("Look At Player")]
        public void LookAtPlayer()
        {
            if (m_Die.gameObject.activeSelf) return;
            if (m_Attack.gameObject.activeSelf) return;
            m_LookAtPlayer.Activate();
        }

        [Button("Kill")]
        public void Kill()
        {
            if (m_Die.gameObject.activeSelf) return;
            DisallowMove();
            m_Die.Activate();
        }
    }
}

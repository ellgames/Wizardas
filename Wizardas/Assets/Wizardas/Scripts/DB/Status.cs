using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.DB
{
    [CreateAssetMenu(menuName = "DB/Status", fileName = "Status")]
    public class Status : SerializedScriptableObject
    {
        [Title("Basic")]
        [OdinSerialize] string m_ActorName = "ActorNameHere";
        public string ActorName
        {
            get { return m_ActorName; }
        }

        [Title("Spec")]
        [OdinSerialize] int m_MaxHP = 1;
        public int MaxHP
        {
            get { return m_MaxHP; }
        }

        [OdinSerialize] int m_HP = 1;
        public int HP
        {
            get { return m_HP; }
        }

        [OdinSerialize] int m_ATK = 1;
        public int ATK
        {
            get { return m_ATK; }
        }

        [OdinSerialize] float m_WalkSpeed = 1f;
        public float WalkSpeed
        {
            get { return m_WalkSpeed; }
        }

        [OdinSerialize] float m_RunSpeed = 3f;
        public float RunSpeed
        {
            get { return m_RunSpeed; }
        }

        [Title("Voice")]
        [OdinSerialize] AudioClip m_DeathVoice;
        public AudioClip DeathVoice
        {
            get { return m_DeathVoice; }
        }

        [Title("Auto")]
        [OdinSerialize] float m_StoppingDistance = 3f;
        public float StoppingDistance
        {
            get { return m_StoppingDistance; }
        }

        [OdinSerialize] float m_AttackDistance = 3f;
        public float AttackDistance
        {
            get { return m_AttackDistance; }
        }

        [Title("Reward")]
        [OdinSerialize] int m_KillPoint;
        public int KillPoint
        {
            get { return m_KillPoint; }
        }
    }
}
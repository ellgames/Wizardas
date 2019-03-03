﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Actor
{
    public class Status : SerializedMonoBehaviour, IDeadWatch
    {
        bool IDeadWatch.IsDead()
        {
            return m_HP == 0;
        }

        [Title("Required")]
        [OdinSerialize, Required] DB.Status m_DefaultStatus;

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

        [Button("Initialize")]
        public void Initialize()
        {
            m_MaxHP = m_DefaultStatus.MaxHP;
            m_HP = m_DefaultStatus.HP;
            m_ATK = m_DefaultStatus.ATK;
            m_WalkSpeed = m_DefaultStatus.WalkSpeed;
            m_RunSpeed = m_DefaultStatus.RunSpeed;
        }
    }
}

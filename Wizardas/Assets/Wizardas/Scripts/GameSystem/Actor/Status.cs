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
    public class Status : SerializedMonoBehaviour, IDeadWatch, Battle.IApplyDamage, UI.Hud.IHPWatch, GameSystem.Score.IKillPoint
    {
        int Score.IKillPoint.KillPoint()
        {
            return m_DefaultStatus.KillPoint;
        }

        int UI.Hud.IHPWatch.MaxHP()
        {
            return m_MaxHP;
        }

        int UI.Hud.IHPWatch.HP()
        {
            return m_HP;
        }

        void Battle.IApplyDamage.ApplyDamage(int damage)
        {
            DecreaseHP(damage);
        }

        bool IDeadWatch.IsDead()
        {
            return m_HP == 0;
        }

        [Title("Required")]
        [OdinSerialize, Required] DB.Status m_DefaultStatus;

        [Title("Settings")]
        [OdinSerialize] bool m_InitializeOnAwake = false;

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

        [Title("State")]
        [OdinSerialize, ReadOnly] bool m_Invincible = false;
        public bool Invincible
        {
            get { return m_Invincible; }
        }

        [Button("無敵化")]
        public void 無敵化()
        {
            m_Invincible = true;
        }

        [Button("無敵状態を解除")]
        public void 無敵状態を解除()
        {
            m_Invincible = false;
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

        public void IncreaseHP(int amount)
        {
            if (m_HP + amount <= m_MaxHP) m_HP += amount;
            else m_HP = m_MaxHP;
        }

        public void DecreaseHP(int amount)
        {
            if (m_Invincible) return;

            if (m_HP - amount > 0) m_HP -= amount;
            else m_HP = 0;
        }

        public void SetMaxHP(int maxHP)
        {
            Debug.Assert(maxHP > 0);

            m_MaxHP = maxHP;
            if (m_HP > maxHP) m_HP = maxHP;
        }

        public void FullRecovery()
        {
            m_HP = m_MaxHP;
        }

        private void Awake()
        {
            if (m_InitializeOnAwake) Initialize();
        }
    }
}

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
    public class Die : EnemyBehaviourBase
    {
        [Title("Required")]
        [OdinSerialize, Required] DB.Status m_Status;

        [Title("Settings")]
        [OdinSerialize] float m_DestroyDelay = 5f;
        [OdinSerialize] GameObject m_DelayedDestroyRoot;

        [Title("Callback")]
        [OdinSerialize] UnityEvent m_OnDied = new UnityEvent();
        [OdinSerialize] UnityEvent m_OnDestroy = new UnityEvent();

        [Title("Animation")]
        [OdinSerialize, Required] Animator m_Animator;
        [OdinSerialize] string m_DieAnimationName;

        [Title("SE")]
        [OdinSerialize, Required] Audio.SEPlayer m_SEPlayer;
        [OdinSerialize] float m_VolumeScale = 0.8f;
        
        float m_ElapsedSec;

        protected override void OnEnable()
        {
            base.OnEnable();

            m_Animator.SetBool(m_DieAnimationName, true);
            m_SEPlayer.PlayOneShot(m_Status.DeathVoice, m_VolumeScale);
            m_OnDied.Invoke();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        protected override void Update()
        {
            base.Update();

            if (m_ElapsedSec >= m_DestroyDelay)
            {
                m_OnDestroy.Invoke();
                Destroy(m_DelayedDestroyRoot);
            }

            m_ElapsedSec += Time.deltaTime;
        }
    }
}

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
    public class Attack : EnemyBehaviourBase
    {
        [Title("Required")]
        [OdinSerialize, Required] Status m_Status;
        [OdinSerialize, Required] Battle.AttackArea m_AttackArea;

        [Title("Settings")]
        [OdinSerialize] float m_HitDelay;

        [Title("Particle")]
        [OdinSerialize] GameObject m_HitParticle;

        [Title("Animation")]
        [OdinSerialize] Animator m_Animator;
        [OdinSerialize] string m_AnimationName;

        [Title("SE")]
        [OdinSerialize] Audio.SEPlayer m_SEPlayer;
        [OdinSerialize] AudioClip m_HitAudioClip;
        [OdinSerialize] float m_HitVolumeScale = 0.8f;


        protected override void OnEnable()
        {
            base.OnEnable();

            m_Animator.SetTrigger(m_AnimationName);
            StartCoroutine(DelayedRun(() => m_AttackArea.Contents.ForEach(content =>
            {
                content.GetHit(m_Status, m_HitAudioClip, m_HitVolumeScale, m_HitParticle);
            }), m_HitDelay));
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        protected override void Update()
        {
            base.Update();
        }

        IEnumerator DelayedRun(System.Action action, float delay)
        {
            yield return new WaitForSeconds(delay);

            action.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Actor.PlayerBehaviour
{
    public class StandardAttackCommand : UseSkillCommandBase
    {
        [Title("Required")]
        [OdinSerialize, Required] Battle.AttackArea m_AttackArea;
        [OdinSerialize, Required] Status m_Status;

        [Title("Settings")]
        [OdinSerialize] float m_HitDelay;

        [Title("Particle")]
        [OdinSerialize] GameObject m_HitParticle;

        [Title("SE")]
        [OdinSerialize] Audio.SEPlayer m_SEPlayer;
        [Space]
        [OdinSerialize] AudioClip m_SwingAudioClip;
        [OdinSerialize] float m_SwingAudioClipDelay = 0.2f;
        [OdinSerialize] float m_SwingVolumeScale = 0.8f;
        [Space]
        [OdinSerialize] AudioClip m_HitAudioClip;
        [OdinSerialize] float m_HitVolumeScale = 0.8f;

        [Title("Animation")]
        [OdinSerialize] Animator m_Animator;
        [OdinSerialize] string m_StandardAttackAnimationName;

        [Title("Trail")]
        [OdinSerialize] XftWeapon.XWeaponTrail m_XweaponTrail1;
        [OdinSerialize] XftWeapon.XWeaponTrail m_XweaponTrail2;
        [OdinSerialize] float m_TrailDuration = 0.6f;
        [OdinSerialize] float m_TrailFadeTime = 0.3f;

        public override void Execute()
        {
            base.Execute();

            Debug.Assert(m_SEPlayer != null);
            StartCoroutine(DelayedRun(m_SwingAudioClipDelay, () => m_SEPlayer.PlayOneShot(m_SwingAudioClip, m_SwingVolumeScale)));

            Debug.Assert(m_Animator != null);
            m_Animator.SetTrigger(m_StandardAttackAnimationName);

            Debug.Assert(m_XweaponTrail1 != null);
            m_XweaponTrail1.Activate();
            StartCoroutine(DelayedRun(m_TrailDuration, () => m_XweaponTrail1.StopSmoothly(m_TrailFadeTime)));

            Debug.Assert(m_XweaponTrail2 != null);
            m_XweaponTrail2.Activate();
            StartCoroutine(DelayedRun(m_TrailDuration, () => m_XweaponTrail2.StopSmoothly(m_TrailFadeTime)));

            Debug.Assert(m_HitParticle != null);
            Debug.Assert(m_SwingAudioClip != null);
            Debug.Assert(m_HitAudioClip != null);
            StartCoroutine(DelayedRun(m_HitDelay, () => Hit()));

            void Hit()
            {
                m_AttackArea.Contents.ForEach(getHitter =>
                {
                    getHitter.GetHit(m_Status, m_HitAudioClip, m_HitVolumeScale, m_HitParticle);
                });
            }
        }

        IEnumerator DelayedRun(float delay, System.Action action)
        {
            yield return new WaitForSeconds(delay);

            action.Invoke();
        }
    }
}

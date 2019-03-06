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
    public class HellAreaCommand : UseSkillCommandBase
    {
        [Title("Required")]
        [OdinSerialize, Required] Battle.AttackArea m_AttackArea;
        [OdinSerialize, Required] Status m_Status;

        [Title("Settings")]
        [OdinSerialize] List<float> m_HitDelaySecs = new List<float>();

        [Title("Particle")]
        [OdinSerialize] float m_EffectParticleDelay = 0.2f;
        [OdinSerialize] GameObject m_EffectParticle;
        [OdinSerialize] GameObject m_HitParticle;

        [Title("SE")]
        [OdinSerialize] Audio.SEPlayer m_SEPlayer;
        [Space]
        [OdinSerialize] AudioClip m_SwingAudioClip;
        [OdinSerialize] float m_SwingAudioClipDelay = 0.2f;
        [OdinSerialize] float m_SwingVolumeScale = 0.8f;
        [Space]
        [OdinSerialize] AudioClip m_HellAreaAudioClip;
        [OdinSerialize] float m_HellAreaAudioClipDelay = 0.2f;
        [OdinSerialize] float m_HellAreaVolumeScale = 0.8f;
        [Space]
        [OdinSerialize] AudioClip m_HitAudioClip;
        [OdinSerialize] float m_HitVolumeScale = 0.8f;

        [Title("Animation")]
        [OdinSerialize] Animator m_Animator;
        [OdinSerialize] string m_HellAreaAnimationName;

        [Title("Trail")]
        [OdinSerialize] XftWeapon.XWeaponTrail m_XweaponTrail1;
        [OdinSerialize] XftWeapon.XWeaponTrail m_XweaponTrail2;
        [OdinSerialize] float m_TrailDuration = 0.6f;
        [OdinSerialize] float m_TrailFadeTime = 0.3f;

        void GenerateEffect()
        {
            var effect = Instantiate(m_EffectParticle);
            effect.transform.position = transform.position;
            effect.transform.parent = transform;
        }

        public override void Execute()
        {
            base.Execute();

            Debug.Assert(m_EffectParticle != null);
            StartCoroutine(DelayedRun(m_EffectParticleDelay, () => GenerateEffect()));

            Debug.Assert(m_AttackArea != null);
            Debug.Assert(m_HitParticle != null);
            Debug.Assert(m_HitDelaySecs != null);
            Debug.Assert(m_HitAudioClip != null);
            m_HitDelaySecs.ForEach(delay =>
            {
                StartCoroutine(DelayedRun(delay, () => m_AttackArea.Contents.ForEach(getHitter =>
                {
                    getHitter.GetHit(m_Status, m_HitAudioClip, m_HitVolumeScale, m_HitParticle);
                })));
            });

            Debug.Assert(m_SEPlayer != null);
            Debug.Assert(m_SwingAudioClip != null);
            Debug.Assert(m_HellAreaAudioClip != null);
            StartCoroutine(DelayedRun(m_SwingAudioClipDelay, () => m_SEPlayer.PlayOneShot(m_SwingAudioClip, m_SwingVolumeScale)));
            StartCoroutine(DelayedRun(m_HellAreaAudioClipDelay, () => m_SEPlayer.PlayOneShot(m_HellAreaAudioClip, m_HellAreaVolumeScale)));

            Debug.Assert(m_Animator != null);
            m_Animator.SetTrigger(m_HellAreaAnimationName);

            Debug.Assert(m_XweaponTrail1 != null);
            m_XweaponTrail1.Activate();
            StartCoroutine(DelayedRun(m_TrailDuration, () => m_XweaponTrail1.StopSmoothly(m_TrailFadeTime)));

            Debug.Assert(m_XweaponTrail2 != null);
            m_XweaponTrail2.Activate();
            StartCoroutine(DelayedRun(m_TrailDuration, () => m_XweaponTrail2.StopSmoothly(m_TrailFadeTime)));
        }

        IEnumerator DelayedRun(float delay, System.Action action)
        {
            yield return new WaitForSeconds(delay);

            action.Invoke();
        }
    }
}

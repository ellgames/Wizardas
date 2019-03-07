using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Battle
{
    public class GetHitter : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] IApplyDamage m_IApplyDamage;

        [Title("Settings")]
        [OdinSerialize] Transform m_HitParticlePoint;
        [OdinSerialize] Audio.SEPlayer m_SEPlayer;

        [Title("Animation")]
        [OdinSerialize] bool m_UsingGetHitAnimation = false;
        [OdinSerialize, EnableIf("m_UsingGetHitAnimation")] Animator m_Animator;
        [OdinSerialize, EnableIf("m_UsingGetHitAnimation")] string m_GetHitAnimationName;

        [Button("Get Hit (Damage Only)")]
        public void GetHit(int damage)
        {
            Debug.Assert(m_IApplyDamage != null);

            m_IApplyDamage.ApplyDamage(damage);

            if (m_UsingGetHitAnimation) m_Animator.SetTrigger(m_GetHitAnimationName);
        }

        public void GetHit(int damage, GameObject hitParticle = null)
        {
            if (hitParticle != null && m_HitParticlePoint != null)
            {
                var particle = Instantiate(hitParticle);
                particle.transform.parent = null;
                particle.transform.position = m_HitParticlePoint.position;
            }

            GetHit(damage);
        }

        public void GetHit(int damage, AudioClip hitSE, float volumeScale = 0.8f, GameObject hitParticle = null)
        {
            Debug.Assert(m_SEPlayer != null);

            m_SEPlayer.PlayOneShot(hitSE, volumeScale);
            GetHit(damage, hitParticle);
        }

        public void GetHit(GameSystem.Actor.Status attackerStatus)
        {
            GetHit(attackerStatus.ATK);
        }

        public void GetHit(GameSystem.Actor.Status attackerStatus, GameObject hitParticle = null)
        {
            GetHit(attackerStatus.ATK, hitParticle);
        }

        public void GetHit(GameSystem.Actor.Status attackerStatus, AudioClip hitSE, float volumeScale = 0.8f, GameObject hitParticle = null)
        {
            GetHit(attackerStatus.ATK, hitSE, volumeScale, hitParticle);
        }
    }
}

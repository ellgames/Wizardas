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

        [Button("Get Hit (Damage Only)")]
        public void GetHit(int damage)
        {
            Debug.Assert(m_IApplyDamage != null);

            m_IApplyDamage.ApplyDamage(damage);
        }

        public void GetHit(int damage, GameObject hitParticle = null)
        {
            Debug.Assert(m_HitParticlePoint != null);

            if (hitParticle != null)
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
    }
}

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
    public class DamageObject : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Battle.AttackArea m_AttackArea;
        [OdinSerialize, Required] Status m_Status;

        [Title("Settings")]
        [OdinSerialize] List<float> m_HitDelaySecs = new List<float>();
        [OdinSerialize] float m_Duration = 3f;

        [Title("Particle")]
        [OdinSerialize] GameObject m_EffectParticle;
        [OdinSerialize] GameObject m_HitParticle;

        [Title("SE")]
        [OdinSerialize] Audio.SEPlayer m_SEPlayer;
        [OdinSerialize] AudioClip m_HitAudioClip;
        [OdinSerialize] float m_HitAudioClipDelay = 0.2f;
        [OdinSerialize] float m_HitVolumeScale = 0.8f;

        private void Awake()
        {
            m_HitDelaySecs.ForEach(delay => StartCoroutine(DelayedHit(delay)));

            var effect = Instantiate(m_EffectParticle);
            effect.transform.parent = gameObject.transform;
            effect.transform.position = transform.position;

            StartCoroutine(DelayedDestroy(m_Duration));
        }

        IEnumerator DelayedDestroy(float delay)
        {
            yield return new WaitForSeconds(delay);

            Destroy(gameObject);
        }

        IEnumerator DelayedHit(float delay)
        {
            yield return new WaitForSeconds(delay);

            m_AttackArea.Contents.ForEach(content => content.GetHit(m_Status, m_HitAudioClip, m_HitVolumeScale, m_HitParticle));
        }
    }
}

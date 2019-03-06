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
        [OdinSerialize] bool m_FitRotationWithParent = true;
        [OdinSerialize] float m_Duration = 3f;
        [OdinSerialize] List<float> m_HitDelaySecs = new List<float>();
        [OdinSerialize] float m_EffectOffsetY = 0.1f;

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
            if (m_FitRotationWithParent) effect.transform.rotation = transform.rotation;
            effect.transform.parent = gameObject.transform;
            effect.transform.position = transform.position;
            effect.transform.position += new Vector3(0f, m_EffectOffsetY, 0f);

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

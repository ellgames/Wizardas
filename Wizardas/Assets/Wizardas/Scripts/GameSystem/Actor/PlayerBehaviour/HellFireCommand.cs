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
    public class HellFireCommand : UseSkillCommandBase
    {
        [Title("Settings")]
        [OdinSerialize] GameObject m_DamageObject;
        [OdinSerialize] float m_DamageObjectGenerationDelay;
        [OdinSerialize] float m_DamageObjectGanerationDistance = 3f;

        [Title("SE")]
        [OdinSerialize] Audio.SEPlayer m_SEPlayer;
        [Space]
        [OdinSerialize] AudioClip m_HellFireAudioClip;
        [OdinSerialize] float m_HellFireAudioClipDelay = 0.2f;
        [OdinSerialize] float m_HellFireVolumeScale = 0.8f;
        [Space]
        [OdinSerialize] AudioClip m_SwingAudioClip;
        [OdinSerialize] float m_SwingAudioClipDelay = 0.2f;
        [OdinSerialize] float m_SwingVolumeScale = 0.8f;

        [Title("Animation")]
        [OdinSerialize] Animator m_Animator;
        [OdinSerialize] string m_HellFireAnimationName;

        [Title("Trail")]
        [OdinSerialize] XftWeapon.XWeaponTrail m_XweaponTrail1;
        [OdinSerialize] XftWeapon.XWeaponTrail m_XweaponTrail2;
        [OdinSerialize] float m_TrailDuration = 0.6f;
        [OdinSerialize] float m_TrailFadeTime = 0.3f;

        void GenerateDamageObject()
        {
            var generated = Instantiate(m_DamageObject);
            generated.transform.parent = null;
            generated.transform.position = transform.position + transform.forward * m_DamageObjectGanerationDistance;
            generated.gameObject.SetActive(true);
        }

        public override void Execute()
        {
            base.Execute();

            StartCoroutine(DelayedRun(m_DamageObjectGenerationDelay, () => GenerateDamageObject()));

            Debug.Assert(m_SEPlayer != null);
            Debug.Assert(m_SwingAudioClip != null);
            Debug.Assert(m_HellFireAudioClip != null);
            StartCoroutine(DelayedRun(m_SwingAudioClipDelay, () => m_SEPlayer.PlayOneShot(m_SwingAudioClip, m_SwingVolumeScale)));
            StartCoroutine(DelayedRun(m_HellFireAudioClipDelay, () => m_SEPlayer.PlayOneShot(m_HellFireAudioClip, m_HellFireVolumeScale)));

            Debug.Assert(m_Animator != null);
            m_Animator.SetTrigger(m_HellFireAnimationName);

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

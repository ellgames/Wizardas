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
    public class QuickCureCommand : UseSkillCommandBase
    {
        [Title("Required")]
        [OdinSerialize] Status m_PlayerStatus;

        [Title("Settings")]
        [OdinSerialize] int m_RecoveryAmount = 500;

        [Title("SE")]
        [OdinSerialize] Audio.SEPlayer m_SEPlayer;
        [OdinSerialize] AudioClip m_AudioClip;
        [OdinSerialize] float m_VolumeScale = 0.8f;

        [Title("Particle")]
        [OdinSerialize] GameObject m_Particle;
        [OdinSerialize] float m_ParticleDuration = 1f;

        [Title("Animation")]
        [OdinSerialize] Animator m_Animator;
        [OdinSerialize] string m_AnimationName;

        [Title("Trail")]
        [OdinSerialize] XftWeapon.XWeaponTrail m_XweaponTrail1;
        [OdinSerialize] XftWeapon.XWeaponTrail m_XweaponTrail2;
        [OdinSerialize] float m_TrailDuration = 0.6f;
        [OdinSerialize] float m_TrailFadeTime = 0.3f;

        [Title("Healing Text")]
        [OdinSerialize] Transform m_Point;
        [OdinSerialize] Guirao.UltimateTextDamage.UltimateTextDamageManager m_UltimateTextDamageManager;
        [OdinSerialize] string m_Key = "heal";

        public override void Execute()
        {
            base.Execute();

            Debug.Assert(m_PlayerStatus != null);
            m_PlayerStatus.IncreaseHP(m_RecoveryAmount);

            Debug.Assert(m_UltimateTextDamageManager != null);
            m_UltimateTextDamageManager.Add("+" + m_RecoveryAmount + "HP", m_Point, m_Key);

            Debug.Assert(m_SEPlayer != null);
            Debug.Assert(m_AudioClip != null);
            m_SEPlayer.PlayOneShot(m_AudioClip, m_VolumeScale);

            Debug.Assert(m_Animator != null);
            m_Animator.SetTrigger(m_AnimationName);

            Debug.Assert(m_XweaponTrail1 != null);
            m_XweaponTrail1.Activate();
            StartCoroutine(DelayedRun(m_TrailDuration, () => m_XweaponTrail1.StopSmoothly(m_TrailFadeTime)));

            Debug.Assert(m_XweaponTrail2 != null);
            m_XweaponTrail2.Activate();
            StartCoroutine(DelayedRun(m_TrailDuration, () => m_XweaponTrail2.StopSmoothly(m_TrailFadeTime)));

            Debug.Assert(m_Particle != null);
            m_Particle.gameObject.SetActive(true);
            StartCoroutine(DelayedRun(m_ParticleDuration, () => m_Particle.gameObject.SetActive(false)));
        }

        IEnumerator DelayedRun(float delay, System.Action action)
        {
            yield return new WaitForSeconds(delay);

            action.Invoke();
        }
    }
}

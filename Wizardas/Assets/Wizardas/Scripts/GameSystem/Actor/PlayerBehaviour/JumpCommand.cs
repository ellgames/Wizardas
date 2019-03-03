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
    public class JumpCommand : UseSkillCommandBase
    {
        [Title("Required")]
        [OdinSerialize, Required] Rigidbody m_Rigidbody;

        [Title("Settings")]
        [OdinSerialize] float m_AddingForce = 20f;
        [OdinSerialize] Vector3 m_JumpDirection = Vector3.up;

        [Title("Advanced Settings")]
        [OdinSerialize] ForceMode m_ForceMode = ForceMode.VelocityChange;

        [Title("SE")]
        [OdinSerialize] bool m_UsingSE = false;
        [OdinSerialize, EnableIf("m_UsingSE")] Audio.SEPlayer m_SEPlayer;
        [OdinSerialize, EnableIf("m_UsingSE")] AudioClip m_JumpAudioClip;
        [OdinSerialize, EnableIf("m_UsingSE")] float m_JumpAudioClipDuration = 1f;
        [OdinSerialize, EnableIf("m_UsingSE")] AudioClip m_LandingAudioClip;
        [OdinSerialize, EnableIf("m_UsingSE")] float m_VolumeScale = 0.8f;

        [Title("Animation")]
        [OdinSerialize] bool m_UsingAnimation = false;
        [OdinSerialize, EnableIf("m_UsingAnimation")] Animator m_Animator;
        [OdinSerialize, EnableIf("m_UsingAnimation")] string m_JumpAnimationName;
        [OdinSerialize, EnableIf("m_UsingAnimation")] float m_JumpAnimationDuration = 1f;

        public override void Execute()
        {
            base.Execute();

            Debug.Assert(m_Rigidbody != null);

            m_Rigidbody.AddForce(m_JumpDirection * m_AddingForce, m_ForceMode);

            if (m_UsingAnimation)
            {
                m_Animator.SetBool(m_JumpAnimationName, true);
                StartCoroutine(DelayedRun(m_JumpAnimationDuration, () => m_Animator.SetBool(m_JumpAnimationName, false)));
            }

            if (m_UsingSE)
            {
                m_SEPlayer.PlayOneShot(m_JumpAudioClip, m_VolumeScale);
                StartCoroutine(DelayedRun(m_JumpAudioClipDuration, () => m_SEPlayer.PlayOneShot(m_LandingAudioClip, m_VolumeScale)));
            }
        }

        IEnumerator DelayedRun(float delay, System.Action action)
        {
            yield return new WaitForSeconds(delay);

            action.Invoke();
        }
    }
}

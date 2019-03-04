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
    /// <summary>
    /// このクラスをアタッチしたGameObjectがアクティブになった時、死亡と判定されます。
    /// </summary>
    public class Die : SerializedMonoBehaviour
    {
        [Title("Callback")]
        [OdinSerialize] UnityEvent m_OnDied = new UnityEvent();
        [OdinSerialize] float m_Delay;
        [OdinSerialize] UnityEvent m_OnDiedDelayed = new UnityEvent();

        [Title("Animation")]
        [OdinSerialize, Required] Animator m_Animator;
        [OdinSerialize] string m_DieAnimationName;

        private void OnEnable()
        {
            m_OnDied.Invoke();
            StartCoroutine(DelayedRun(m_Delay, () => m_OnDiedDelayed.Invoke()));

            m_Animator.SetBool(m_DieAnimationName, true);
        }

        IEnumerator DelayedRun(float delay, System.Action action)
        {
            yield return new WaitForSeconds(delay);

            action.Invoke();
        }
    }
}

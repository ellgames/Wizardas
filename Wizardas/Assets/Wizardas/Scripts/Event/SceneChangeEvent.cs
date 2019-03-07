using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Event
{
    public class SceneChangeEvent : EventBase
    {
        [Title("Settings")]
        [OdinSerialize] string m_NextSceneName;

        public override void Invoke()
        {
            base.Invoke();

#if UNITY_EDITOR
            if (m_NextSceneName == null) Debug.Log("Next scene name is null.");
#endif

            UnityEngine.SceneManagement.SceneManager.LoadScene(m_NextSceneName);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem
{
    public class LogoSceneManager : SerializedMonoBehaviour
    {
        [OdinSerialize] Profile.SystemProfile m_SystemProfile;
        [OdinSerialize] GameObject m_LoadEvent;
        [OdinSerialize] GameObject m_SceneChangeEvent;

        private void Awake()
        {
            m_LoadEvent.gameObject.SetActive(true);
            if (m_SystemProfile.StartFromTitle) m_SceneChangeEvent.gameObject.SetActive(true);
        }
    }
}

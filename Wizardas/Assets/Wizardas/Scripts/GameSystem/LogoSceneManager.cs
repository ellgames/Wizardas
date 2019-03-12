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
        [OdinSerialize] GameObject m_SceneChangeEvent;

        private void Awake()
        {
            if (m_SystemProfile.StartFromTitle) m_SceneChangeEvent.gameObject.SetActive(true);
        }
    }
}

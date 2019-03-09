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
    public class TutorialManager : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;
        [OdinSerialize, Required] GameObject m_Tutorial;

        private void Awake()
        {
            if (m_SystemProfile.Tutorial)
            {
                m_Tutorial.gameObject.SetActive(true);
                m_SystemProfile.Tutorial = false;
            }
        }
    }
}

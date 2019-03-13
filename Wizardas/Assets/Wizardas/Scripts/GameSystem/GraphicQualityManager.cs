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
    public class GraphicQualityManager : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;

        [Title("Settings")]
        [OdinSerialize] GameObject m_CameraForHighSpec;
        [OdinSerialize] GameObject m_CameraForLowSpec;

        private void Awake()
        {
            m_CameraForHighSpec.gameObject.SetActive(false);
            m_CameraForLowSpec.gameObject.SetActive(false);

            if (m_SystemProfile.LowSpecMode)
            {
                m_CameraForLowSpec.gameObject.SetActive(true);
            }
            else
            {
                m_CameraForHighSpec.gameObject.SetActive(true);
            }
        }
    }
}

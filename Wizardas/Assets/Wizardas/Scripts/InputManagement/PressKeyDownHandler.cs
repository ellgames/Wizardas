using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.InputManagement
{
    public class PressKeyDownHandler : SerializedMonoBehaviour
    {
        [Title("Requried")]
        [OdinSerialize, Required] Config.KeyConfig m_KeyConfig;

        [Title("Settings")]
        [OdinSerialize] UnityEvent m_OnCancel = new UnityEvent();
        [OdinSerialize] UnityEvent m_OnYes = new UnityEvent();

        private void Update()
        {
            if (Input.GetKeyDown(m_KeyConfig.YesKey))
            {
                m_OnYes.Invoke();
            }

            if (Input.GetKeyDown(m_KeyConfig.CancelKey))
            {
                m_OnCancel.Invoke();
            }
        }
    }
}

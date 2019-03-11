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
    public class PressCancelDownHandler : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Config.KeyConfig m_KeyConfig;

        [Title("Callback")]
        [OdinSerialize] UnityEvent m_OnPressCancel = new UnityEvent();

        private void Update()
        {
            if (Input.GetKeyDown(m_KeyConfig.CancelKey)) m_OnPressCancel.Invoke();
        }
    }
}

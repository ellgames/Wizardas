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
    public class PressAnyKeyDownHandler : SerializedMonoBehaviour
    {
        [Title("Callback")]
        [OdinSerialize] UnityEvent m_OnPressAnyKeyDown = new UnityEvent();

        private void Update()
        {
            if (Input.anyKeyDown) m_OnPressAnyKeyDown.Invoke();
        }
    }
}

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
    public class SkyboxChangeEvent : EventBase
    {
        [Title("Settings")]
        [OdinSerialize] Material m_Skybox;

        public override void Invoke()
        {
            base.Invoke();

            RenderSettings.skybox = m_Skybox;
        }
    }
}

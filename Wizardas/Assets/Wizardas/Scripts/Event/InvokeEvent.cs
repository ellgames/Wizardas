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
    public class InvokeEvent : EventBase
    {
        [Title("Settings")]
        [OdinSerialize] UnityEvent m_Invokable = new UnityEvent();

        public override void Invoke()
        {
            base.Invoke();

            m_Invokable.Invoke();
        }
    }
}

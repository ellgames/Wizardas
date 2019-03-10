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
    public class LoadEvent : EventBase
    {
        [Title("Required")]
        [OdinSerialize] Save.SaveHandler m_SaveHandler;

        public override void Invoke()
        {
            base.Invoke();

            m_SaveHandler.Load();
        }
    }
}

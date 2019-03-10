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
    public class HighScoreUpdateEvent : EventBase
    {
        [Title("Required")]

        public override void Invoke()
        {
            base.Invoke();

            // TODO
        }
    }
}

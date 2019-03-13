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
    public class ScoreInitializeEvent : EventBase
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.ScoreProfile m_ScoreProfile;

        public override void Invoke()
        {
            base.Invoke();

            m_ScoreProfile.Initialize();
        }
    }
}

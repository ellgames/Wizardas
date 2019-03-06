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
    public class AddScoreEvent : EventBase
    {
        [Title("Required")]
        [OdinSerialize, Required] GameSystem.Score.ScoreManager m_ScoreManager;
        [OdinSerialize, Required] GameSystem.Score.IKillPoint m_IKillPoint;
        [OdinSerialize, Required] Transform m_AddScoreEffectPoint;

        public override void Invoke()
        {
            base.Invoke();

            m_ScoreManager.AddScore(m_IKillPoint, m_AddScoreEffectPoint);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Profile
{
    [CreateAssetMenu(menuName = "Profile/ScoreProfile", fileName = "ScoreProfile")]
    public class ScoreProfile : SerializedScriptableObject
    {
        [OdinSerialize] int m_Score;
        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        [Button("Initialize")]
        public void Initialize()
        {
            m_Score = 0;
        }

        public void AddScore(int score)
        {
            m_Score += score;
        }
    }
}
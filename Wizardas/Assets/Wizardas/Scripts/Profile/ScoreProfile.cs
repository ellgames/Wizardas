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

        [OdinSerialize] string m_ActorName;
        public string ActorName
        {
            get { return m_ActorName; }
            set { m_ActorName = value; }
        }
        
        [OdinSerialize] Meta.DateTime m_DateTime;
        public Meta.DateTime DateTime
        {
            get { return m_DateTime; }
            set { m_DateTime = value; }
        }

        [Button("Initialize")]
        public void Initialize()
        {
            m_Score = 0;
            m_ActorName = "";
            m_DateTime = Meta.DateTime.Zero();
        }

        public void AddScore(int score)
        {
            m_Score += score;
        }

        public void Copy(ScoreProfile profile)
        {
            m_Score = profile.Score;
            m_ActorName = profile.ActorName;
            m_DateTime = profile.DateTime;
        }
    }
}
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
    public class ScoreProfile : SerializedScriptableObject, Save.ISavable
    {
        void Save.ISavable.Save()
        {
            ES2.Save(m_Score, GetInstanceID() + "ScoreProfile/Score");
            if (m_ActorName != null) ES2.Save(m_ActorName, GetInstanceID() + "ScoreProfile/ActorName");
            ES2.Save(m_DateTime.Year, GetInstanceID() + "ScoreProfile/DateTime_Year");
            ES2.Save(m_DateTime.Month, GetInstanceID() + "ScoreProfile/DateTime_Month");
            ES2.Save(m_DateTime.Day, GetInstanceID() + "ScoreProfile/DateTime_Day");
            ES2.Save(m_DateTime.Hour, GetInstanceID() + "ScoreProfile/DateTime_Hour");
            ES2.Save(m_DateTime.Minute, GetInstanceID() + "ScoreProfile/DateTime_Minute");
            ES2.Save(m_DateTime.Second, GetInstanceID() + "ScoreProfile/DateTime_Second");
        }

        void Save.ISavable.Load()
        {
            m_Score = ES2.Load<int>("ScoreProfile/Score");
            if (ES2.Load<string>("ScoreProfile/ActorName") != null)
            {
                m_ActorName = ES2.Load<string>(GetInstanceID() + "ScoreProfile/ActorName");
            }
            m_DateTime.Year = ES2.Load<int>(GetInstanceID() + "ScoreProfile/DateTime_Year");
            m_DateTime.Month = ES2.Load<int>(GetInstanceID() + "ScoreProfile/DateTime_Month");
            m_DateTime.Day = ES2.Load<int>(GetInstanceID() + "ScoreProfile/DateTime_Day");
            m_DateTime.Hour = ES2.Load<int>(GetInstanceID() + "ScoreProfile/DateTime_Hour");
            m_DateTime.Minute = ES2.Load<int>(GetInstanceID() + "ScoreProfile/DateTime_Minute");
            m_DateTime.Second = ES2.Load<int>(GetInstanceID() + "ScoreProfile/DateTime_Second");
        }

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
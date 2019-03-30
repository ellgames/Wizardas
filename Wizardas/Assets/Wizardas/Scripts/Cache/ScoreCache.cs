using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Cache
{
    [CreateAssetMenu(menuName = "Profile/ScoreCache", fileName = "ScoreCache")]
    public class ScoreCache : SerializedMonoBehaviour, Save.ISavable
    {
        [OdinSerialize] string Eigenvalue;

        void Save.ISavable.Save()
        {
            ES2.Save(m_Score, "ScoreProfile/Score" + Eigenvalue);
            if (m_ActorName != null) ES2.Save(m_ActorName, "ScoreProfile/ActorName" + Eigenvalue);
            ES2.Save(m_DateTime.Year, "ScoreProfile/DateTime_Year" + Eigenvalue);
            ES2.Save(m_DateTime.Month, "ScoreProfile/DateTime_Month" + Eigenvalue);
            ES2.Save(m_DateTime.Day, "ScoreProfile/DateTime_Day" + Eigenvalue);
            ES2.Save(m_DateTime.Hour, "ScoreProfile/DateTime_Hour" + Eigenvalue);
            ES2.Save(m_DateTime.Minute, "ScoreProfile/DateTime_Minute" + Eigenvalue);
            ES2.Save(m_DateTime.Second, "ScoreProfile/DateTime_Second" + Eigenvalue);
        }

        void Save.ISavable.Load()
        {
            m_Score = ES2.Load<int>("ScoreProfile/Score" + Eigenvalue);
            if (ES2.Exists("ScoreProfile/ActorName" + Eigenvalue))
            {
                m_ActorName = ES2.Load<string>("ScoreProfile/ActorName" + Eigenvalue);
            }
            m_DateTime.Year = ES2.Load<int>("ScoreProfile/DateTime_Year" + Eigenvalue);
            m_DateTime.Month = ES2.Load<int>("ScoreProfile/DateTime_Month" + Eigenvalue);
            m_DateTime.Day = ES2.Load<int>("ScoreProfile/DateTime_Day" + Eigenvalue);
            m_DateTime.Hour = ES2.Load<int>("ScoreProfile/DateTime_Hour" + Eigenvalue);
            m_DateTime.Minute = ES2.Load<int>("ScoreProfile/DateTime_Minute" + Eigenvalue);
            m_DateTime.Second = ES2.Load<int>("ScoreProfile/DateTime_Second" + Eigenvalue);
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

        public void Copy(ScoreCache profile)
        {
            m_Score = profile.Score;
            m_ActorName = profile.ActorName;
            m_DateTime = profile.DateTime;
        }
    }
}
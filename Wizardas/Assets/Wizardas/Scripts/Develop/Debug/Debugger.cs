using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using D = UnityEngine.Debug;

namespace EllGames.Wiz.Develop.Debug
{
    public class Debugger : SerializedMonoBehaviour
    {
        [OdinSerialize] Profile.ScoreProfile m_HighScoreProfile_FF_MA;
        [OdinSerialize] Profile.ScoreProfile m_LatestScoreProfile;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                D.LogError("==============================================");
                D.LogError("# Data in Profiles");
                D.LogError("HighScore_FF_MA = " + m_HighScoreProfile_FF_MA.Score);
                D.LogError("LatestScore = " + m_LatestScoreProfile.Score);
                D.LogError("# Loaded Data");
                D.LogError("HighScore_FF_MA = " + ES2.Load<int>("ScoreProfile/Score" + 3.ToString()));
                D.LogError("LatestScore = " + ES2.Load<int>("ScoreProfile/Score" + 1.ToString()));
            }
        }
    }
}

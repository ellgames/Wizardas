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
        [OdinSerialize, Required] Profile.GameProfile m_LatestGameProfile;
        [OdinSerialize, Required] Profile.PlayerProfile m_PlayerProfile;
        [OdinSerialize, Required] Profile.ScoreProfile m_LatestScoreProfile;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_LF_MA;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_LF_IM;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_FF_MA;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_FF_IM;

        [Title("Settings")]
        [OdinSerialize] UnityEvent m_OnNewHighScoreRecorded = new UnityEvent();

        public override void Invoke()
        {
            base.Invoke();

            var dateTime = new Meta.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, System.DateTime.Now.Hour, System.DateTime.Now.Minute, System.DateTime.Now.Second);
            m_LatestScoreProfile.DateTime = dateTime;

            Profile.ScoreProfile highScoreProfile = null;

            switch (m_LatestGameProfile.GameMode)
            {
                case Meta.GAME_MODE.LimitFight:
                    switch (m_LatestGameProfile.GameDifficulty)
                    {
                        case Meta.GAME_DIFFICULTY.Master:
                            highScoreProfile = m_HighScoreProfile_LF_MA;
                            break;
                        case Meta.GAME_DIFFICULTY.Impossible:
                            highScoreProfile = m_HighScoreProfile_LF_IM;
                            break;
                    }
                    break;
                case Meta.GAME_MODE.FinalFight:
                    switch (m_LatestGameProfile.GameDifficulty)
                    {
                        case Meta.GAME_DIFFICULTY.Master:
                            highScoreProfile = m_HighScoreProfile_FF_MA;
                            break;
                        case Meta.GAME_DIFFICULTY.Impossible:
                            highScoreProfile = m_HighScoreProfile_FF_IM;
                            break;
                    }
                    break;
            }

            if (highScoreProfile != null)
            {
                if (m_LatestScoreProfile.Score >= highScoreProfile.Score)
                {
                    highScoreProfile.Copy(m_LatestScoreProfile);
                    highScoreProfile.ActorName = m_PlayerProfile.PlayerName;
                    if (m_OnNewHighScoreRecorded != null) m_OnNewHighScoreRecorded.Invoke();
                }
            }
        }
    }
}

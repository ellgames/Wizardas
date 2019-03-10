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
        [OdinSerialize, Required] Profile.ScoreProfile m_LatestScoreProfile;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_LF_MA;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_LF_IM;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_FF_MA;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_FF_IM;

        public override void Invoke()
        {
            base.Invoke();

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

            if (highScoreProfile != null) highScoreProfile.Copy(m_LatestScoreProfile);
        }
    }
}

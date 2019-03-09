using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI.Hud
{
    [RequireComponent(typeof(Text))]
    public class HudHighScoreNotificationText : HudComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_LF_MA;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_LF_IM;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_FF_MA;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_FF_IM;

        [Title("State")]
        [OdinSerialize] Meta.GAME_MODE m_TargetMode;
        public Meta.GAME_MODE TargetMode
        {
            get { return m_TargetMode; }
        }

        [OdinSerialize] Meta.GAME_DIFFICULTY m_TargetDifficulty;
        public Meta.GAME_DIFFICULTY TargetDifficulty
        {
            get { return m_TargetDifficulty; }
        }

        [Title("Settings")]
        [OdinSerialize] string m_TitleLabel_Jpn = "# ハイスコア";
        [OdinSerialize] string m_TitleLabel_Eng = "# High Score";
        [Space]
        [OdinSerialize] string m_HighScoreLabel_Jpn = "スコア : ";
        [OdinSerialize] string m_HighScoreLabel_Eng = "SCORE : ";
        [OdinSerialize] string m_HighScoreUnit_Jpn = "ポイント";
        [OdinSerialize] string m_HighScoreUnit_Eng = "Points";
        [Space]
        [OdinSerialize] string m_ActorNameLabel_Jpn = "名前 : ";
        [OdinSerialize] string m_ActorNameLabel_Eng = "NAME : ";
        [Space]
        [OdinSerialize] string m_DateTimeLabel_Jpn = "記録日 : ";
        [OdinSerialize] string m_DateTimeLabel_Eng = "DATE : ";
        
        [Title("Advanced Settings")]
        [OdinSerialize] string m_NoRecordString = "-";
        [OdinSerialize] string m_DateTimeSeparator = "/";

        Text m_Text;

        Profile.ScoreProfile HighScoreProfile()
        {
            switch (m_TargetMode)
            {
                case Meta.GAME_MODE.LimitFight:
                    switch (m_TargetDifficulty)
                    {
                        case Meta.GAME_DIFFICULTY.Master:
                            return m_HighScoreProfile_LF_MA;
                        case Meta.GAME_DIFFICULTY.Impossible:
                            return m_HighScoreProfile_LF_IM;
                    }
                    break;
                case Meta.GAME_MODE.FinalFight:
                    switch (m_TargetDifficulty)
                    {
                        case Meta.GAME_DIFFICULTY.Master:
                            return m_HighScoreProfile_FF_MA;
                        case Meta.GAME_DIFFICULTY.Impossible:
                            return m_HighScoreProfile_FF_IM;
                    }
                    break;
            }

            return null;
        }

        string DateTimeString(Meta.DateTime dateTime)
        {
            return dateTime.Year.ToString("D4") + m_DateTimeSeparator + dateTime.Month.ToString("D2") + m_DateTimeSeparator + dateTime.Day.ToString("D2");
        }

        private void Awake()
        {
            m_Text = GetComponent<Text>();
        }

        private void Update()
        {
            Debug.Assert(m_Text != null);

            string title = "";
            string highScore = "";
            string actorName = "";
            string dateTime = "";

            if (HighScoreProfile() == null)
            {
                switch (m_SystemProfile.Language)
                {
                    case Meta.LANGUAGE.Japanese:
                        title = m_TitleLabel_Jpn;
                        highScore = m_HighScoreLabel_Jpn + m_NoRecordString;
                        actorName = m_ActorNameLabel_Jpn + m_NoRecordString;
                        dateTime = m_DateTimeLabel_Jpn + m_NoRecordString;
                        break;
                    case Meta.LANGUAGE.English:
                        title = m_TitleLabel_Eng;
                        highScore = m_HighScoreLabel_Eng + m_NoRecordString;
                        actorName = m_ActorNameLabel_Eng + m_NoRecordString;
                        dateTime = m_DateTimeLabel_Eng + m_NoRecordString;
                        break;
                }
            }
            else
            {
                switch (m_SystemProfile.Language)
                {
                    case Meta.LANGUAGE.Japanese:
                        title = m_TitleLabel_Jpn;
                        highScore = m_HighScoreLabel_Jpn + HighScoreProfile().Score.ToString("N0") + " " + m_HighScoreUnit_Jpn;
                        actorName = m_ActorNameLabel_Jpn + HighScoreProfile().ActorName;
                        dateTime = m_DateTimeLabel_Jpn + DateTimeString(HighScoreProfile().DateTime);
                        break;
                    case Meta.LANGUAGE.English:
                        title = m_TitleLabel_Eng;
                        highScore = m_HighScoreLabel_Eng + HighScoreProfile().Score.ToString("N0") + " " + m_HighScoreUnit_Eng;
                        actorName = m_ActorNameLabel_Eng + HighScoreProfile().ActorName;
                        dateTime = m_DateTimeLabel_Eng + DateTimeString(HighScoreProfile().DateTime);
                        break;
                }
            }

            m_Text.text = title + "\n" + highScore + "\n" + actorName + "\n" + dateTime;
        }
    }
}

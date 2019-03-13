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
    public class HudGameModeDescriptionText : HudComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;
        [OdinSerialize, Required] Profile.GameProfile m_LatestGameProfile;

        [Title("Settings")]
        [OdinSerialize] string m_TrainingMode_Jpn = "練習モード(プレイヤーは無敵)";
        [OdinSerialize] string m_TrainingMode_Eng = "Description";
        [OdinSerialize] string m_LimitFightMode_Jpn = "3分間のスコアアタック";
        [OdinSerialize] string m_LimitFightMode_Eng = "Description";
        [OdinSerialize] string m_FinalFightMode_Jpn = "死ぬまで戦う。一撃でも喰らうと即死";
        [OdinSerialize] string m_FinalFightMode_Eng = "Description";

        Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();
        }

        private void Update()
        {
            switch (m_LatestGameProfile.GameMode)
            {
                case Meta.GAME_MODE.Training:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.English:
                            m_Text.text = m_TrainingMode_Eng;
                            break;
                        case Meta.LANGUAGE.Japanese:
                            m_Text.text = m_TrainingMode_Jpn;
                            break;
                    }
                    break;
                case Meta.GAME_MODE.LimitFight:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.English:
                            m_Text.text = m_LimitFightMode_Eng;
                            break;
                        case Meta.LANGUAGE.Japanese:
                            m_Text.text = m_LimitFightMode_Jpn;
                            break;
                    }
                    break;
                case Meta.GAME_MODE.FinalFight:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.English:
                            m_Text.text = m_FinalFightMode_Eng;
                            break;
                        case Meta.LANGUAGE.Japanese:
                            m_Text.text = m_FinalFightMode_Jpn;
                            break;
                    }
                    break;
            }
        }
    }
}

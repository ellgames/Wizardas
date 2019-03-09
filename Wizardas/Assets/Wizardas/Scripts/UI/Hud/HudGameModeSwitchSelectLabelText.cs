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
    public class HudGameModeSwitchSelectLabelText : HudComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;

        [Title("Settings")]
        [OdinSerialize] Text m_OriginalText;
        [OdinSerialize] string m_TrainingModeOption = "Training";
        [OdinSerialize] string m_LimitFightOption = "Limit Fight";
        [OdinSerialize] string m_FinalFightOption = "Final Fight";

        [Title("Japanese Labels")]
        [OdinSerialize] string m_TrainingModeString_Jpn = "トレーニング";
        [OdinSerialize] string m_LimitFightModeString_Jpn = "リミットファイト";
        [OdinSerialize] string m_FinalFightModeString_Jpn = "ファイナルファイト";

        [Title("English Labels")]
        [OdinSerialize] string m_TrainingModeString_Eng = "Training";
        [OdinSerialize] string m_LimitFightModeString_Eng = "Limit Fight";
        [OdinSerialize] string m_FinalFightModeString_Eng = "Final Fight";

        Text m_Text;

        Meta.GAME_MODE GameMode()
        {
            if (m_OriginalText.text == m_TrainingModeOption)
            {
                return Meta.GAME_MODE.Training;
            }
            else if (m_OriginalText.text == m_LimitFightOption)
            {
                return Meta.GAME_MODE.LimitFight;
            }
            else if (m_OriginalText.text == m_FinalFightOption)
            {
                return Meta.GAME_MODE.FinalFight;
            }

#if UNITY_EDITOR
            Debug.Log("ゲームモードを正常に取得できませんでした。");
#endif

            return Meta.GAME_MODE.Training;
        }

        private void Awake()
        {
            m_Text = GetComponent<Text>();
        }

        private void Update()
        {
            Debug.Assert(m_Text != null);

            switch (m_SystemProfile.Language)
            {
                case Meta.LANGUAGE.Japanese:
                    switch (GameMode())
                    {
                        case Meta.GAME_MODE.Training:
                            m_Text.text = m_TrainingModeString_Jpn;
                            break;
                        case Meta.GAME_MODE.LimitFight:
                            m_Text.text = m_LimitFightModeString_Jpn;
                            break;
                        case Meta.GAME_MODE.FinalFight:
                            m_Text.text = m_FinalFightModeString_Jpn;
                            break;
                    }
                    break;
                case Meta.LANGUAGE.English:
                    switch (GameMode())
                    {
                        case Meta.GAME_MODE.Training:
                            m_Text.text = m_TrainingModeString_Eng;
                            break;
                        case Meta.GAME_MODE.LimitFight:
                            m_Text.text = m_LimitFightModeString_Eng;
                            break;
                        case Meta.GAME_MODE.FinalFight:
                            m_Text.text = m_FinalFightModeString_Eng;
                            break;
                    }
                    break;
            }
        }
    }
}

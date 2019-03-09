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
    public class HudGameDifficultySwitchSelectLabelText : HudComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;

        [Title("Settings")]
        [OdinSerialize] Text m_OriginalText;
        [OdinSerialize] string m_NoviceOption = "Novice";
        [OdinSerialize] string m_HardOption = "Hard";
        [OdinSerialize] string m_VeteranOption = "Veteran";
        [OdinSerialize] string m_MasterOption = "Master";
        [OdinSerialize] string m_ImpossibleOption = "Impossible";

        [Title("Japanese Labels")]
        [OdinSerialize] string m_NoviceString_Jpn = "ノービス";
        [OdinSerialize] string m_HardString_Jpn = "ハード";
        [OdinSerialize] string m_VeteranString_Jpn = "ベテラン";
        [OdinSerialize] string m_MasterString_Jpn = "マスター";
        [OdinSerialize] string m_ImpossibleString_Jpn = "インポッシブル";

        [Title("English Labels")]
        [OdinSerialize] string m_NoviceString_Eng = "Novice";
        [OdinSerialize] string m_HardString_Eng = "Hard";
        [OdinSerialize] string m_VeteranString_Eng = "Veteran";
        [OdinSerialize] string m_MasterString_Eng = "Master";
        [OdinSerialize] string m_ImpossibleString_Eng = "Impossible";

        Text m_Text;

        Meta.GAME_DIFFICULTY GameMode()
        {
            if (m_OriginalText.text == m_NoviceOption)
            {
                return Meta.GAME_DIFFICULTY.Novice;
            }
            else if (m_OriginalText.text == m_HardOption)
            {
                return Meta.GAME_DIFFICULTY.Hard;
            }
            else if (m_OriginalText.text == m_VeteranOption)
            {
                return Meta.GAME_DIFFICULTY.Veteran;
            }
            else if (m_OriginalText.text == m_MasterOption)
            {
                return Meta.GAME_DIFFICULTY.Master;
            }
            else if (m_OriginalText.text == m_ImpossibleOption)
            {
                return Meta.GAME_DIFFICULTY.Impossible;
            }

#if UNITY_EDITOR
            Debug.Log("難易度を正常に取得できませんでした。");
#endif

            return Meta.GAME_DIFFICULTY.Novice;
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
                        case Meta.GAME_DIFFICULTY.Novice:
                            m_Text.text = m_NoviceString_Jpn;
                            break;
                        case Meta.GAME_DIFFICULTY.Hard:
                            m_Text.text = m_HardString_Jpn;
                            break;
                        case Meta.GAME_DIFFICULTY.Veteran:
                            m_Text.text = m_VeteranString_Jpn;
                            break;
                        case Meta.GAME_DIFFICULTY.Master:
                            m_Text.text = m_MasterString_Jpn;
                            break;
                        case Meta.GAME_DIFFICULTY.Impossible:
                            m_Text.text = m_ImpossibleString_Jpn;
                            break;
                    }
                    break;
                case Meta.LANGUAGE.English:
                    switch (GameMode())
                    {
                        case Meta.GAME_DIFFICULTY.Novice:
                            m_Text.text = m_NoviceString_Eng;
                            break;
                        case Meta.GAME_DIFFICULTY.Hard:
                            m_Text.text = m_HardString_Eng;
                            break;
                        case Meta.GAME_DIFFICULTY.Veteran:
                            m_Text.text = m_VeteranString_Eng;
                            break;
                        case Meta.GAME_DIFFICULTY.Master:
                            m_Text.text = m_MasterString_Eng;
                            break;
                        case Meta.GAME_DIFFICULTY.Impossible:
                            m_Text.text = m_ImpossibleString_Eng;
                            break;
                    }
                    break;
            }
        }
    }
}

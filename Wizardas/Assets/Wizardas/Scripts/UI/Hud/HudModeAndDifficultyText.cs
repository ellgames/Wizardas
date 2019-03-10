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
    public class HudModeAndDifficultyText : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;
        [OdinSerialize, Required] Profile.GameProfile m_LatestGameProfile;

        [Title("Settings")]
        [OdinSerialize] string m_Separator = ", ";

        Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();
        }

        private void Update()
        {
            Debug.Assert(m_Text != null);

            var mode = "";
            var difficulty = "";

            switch (m_LatestGameProfile.GameMode)
            {
                case Meta.GAME_MODE.Training:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.Japanese:
                            mode = "トレーニング";
                            break;
                        case Meta.LANGUAGE.English:
                            mode = "Training";
                            break;
                    }
                    break;
                case Meta.GAME_MODE.LimitFight:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.Japanese:
                            mode = "リミットファイト";
                            break;
                        case Meta.LANGUAGE.English:
                            mode = "Limit Fight";
                            break;
                    }
                    break;
                case Meta.GAME_MODE.FinalFight:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.Japanese:
                            mode = "ファイナルファイト";
                            break;
                        case Meta.LANGUAGE.English:
                            mode = "Final Fight";
                            break;
                    }
                    break;
            }

            switch (m_LatestGameProfile.GameDifficulty)
            {
                case Meta.GAME_DIFFICULTY.Novice:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.Japanese:
                            difficulty = "ノービス";
                            break;
                        case Meta.LANGUAGE.English:
                            difficulty = "Novice";
                            break;
                    }
                    break;
                case Meta.GAME_DIFFICULTY.Hard:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.Japanese:
                            difficulty = "ハード";
                            break;
                        case Meta.LANGUAGE.English:
                            difficulty = "Hard";
                            break;
                    }
                    break;
                case Meta.GAME_DIFFICULTY.Veteran:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.Japanese:
                            difficulty = "ベテラン";
                            break;
                        case Meta.LANGUAGE.English:
                            difficulty = "Veteran";
                            break;
                    }
                    break;
                case Meta.GAME_DIFFICULTY.Master:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.Japanese:
                            difficulty = "マスター";
                            break;
                        case Meta.LANGUAGE.English:
                            difficulty = "Master";
                            break;
                    }
                    break;
                case Meta.GAME_DIFFICULTY.Impossible:
                    switch (m_SystemProfile.Language)
                    {
                        case Meta.LANGUAGE.Japanese:
                            difficulty = "インポッシブル";
                            break;
                        case Meta.LANGUAGE.English:
                            difficulty = "Impossible";
                            break;
                    }
                    break;
            }

            m_Text.text = "(" + mode + m_Separator + difficulty + ")";
        }
    }
}

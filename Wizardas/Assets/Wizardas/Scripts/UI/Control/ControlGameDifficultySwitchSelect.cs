﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI.Control
{
    public class ControlGameDifficultySwitchSelect : ControlComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.GameProfile m_LatestGameProfile;
        [OdinSerialize, Required] DuloGames.UI.UISwitchSelect m_UISwitchSelect;

        [Title("Settings")]
        [OdinSerialize] Dictionary<int, Meta.GAME_DIFFICULTY> m_SelectedOptionIndexGameDifficultyPairs = new Dictionary<int, Meta.GAME_DIFFICULTY>();

        int SearchIndex(Meta.GAME_DIFFICULTY difficulty)
        {
            foreach (var pair in m_SelectedOptionIndexGameDifficultyPairs)
            {
                if (difficulty == pair.Value)
                {
                    return pair.Key;
                }
            }

            return -1;
        }

        private void Awake()
        {
            var latest = m_LatestGameProfile.GameDifficulty;
            m_UISwitchSelect.SelectOptionByIndex(SearchIndex(latest));
        }

        private void Update()
        {
            foreach (var pair in m_SelectedOptionIndexGameDifficultyPairs)
            {
                if (pair.Key == m_UISwitchSelect.selectedOptionIndex)
                {
                    m_LatestGameProfile.GameDifficulty = pair.Value;
                }
            }
        }
    }
}

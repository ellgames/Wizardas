using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI.Control
{
    public class ControlGameModeSwitchSelect : ControlComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.GameProfile m_LatestGameProfile;
        [OdinSerialize, Required] DuloGames.UI.UISwitchSelect m_UISwitchSelect;

        [Title("Settings")]
        [OdinSerialize] Dictionary<int, Meta.GAME_MODE> m_SelectedOptionIndexGameModePairs = new Dictionary<int, Meta.GAME_MODE>();

        int SearchIndex(Meta.GAME_MODE mode)
        {
            foreach (var pair in m_SelectedOptionIndexGameModePairs)
            {
                if (mode == pair.Value)
                {
                    return pair.Key;
                }
            }

            return -1;
        }

        private void Awake()
        {
            var latest = m_LatestGameProfile.GameMode;
            m_UISwitchSelect.SelectOptionByIndex(SearchIndex(latest));
        }

        private void Update()
        {
            foreach (var pair in m_SelectedOptionIndexGameModePairs)
            {
                if (pair.Key == m_UISwitchSelect.selectedOptionIndex)
                {
                    m_LatestGameProfile.GameMode = pair.Value;
                }
            }
        }
    }
}

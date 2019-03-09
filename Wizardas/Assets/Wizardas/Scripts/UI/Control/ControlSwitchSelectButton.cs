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
    public class ControlSwitchSelectButton : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] DuloGames.UI.UISwitchSelect m_UISwitchSelect;

        [Button("Select Next Option")]
        public void SelectNextOption()
        {
            var nextIndex = m_UISwitchSelect.selectedOptionIndex + 1;

            if (nextIndex < 0) nextIndex = m_UISwitchSelect.options.Count - 1;
            if (nextIndex >= m_UISwitchSelect.options.Count) nextIndex = 0;

            m_UISwitchSelect.SelectOptionByIndex(nextIndex);
        }

        [Button("Select Previous Option")]
        public void SelectPreviousOption()
        {
            var previousIndex = m_UISwitchSelect.selectedOptionIndex - 1;

            if (previousIndex < 0) previousIndex = m_UISwitchSelect.options.Count - 1;
            if (previousIndex >= m_UISwitchSelect.options.Count) previousIndex = 0;

            m_UISwitchSelect.SelectOptionByIndex(previousIndex);
        }
    }
}

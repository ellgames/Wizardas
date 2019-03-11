using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI.Window
{
    public class ConfigWindow : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;

        [OdinSerialize] Toggle m_UseEnglishToggle;
        [OdinSerialize] Toggle m_UseJapaneseToggle;
        [OdinSerialize] Toggle m_StartFromTitleToggle;
        [OdinSerialize] Toggle m_LowSpecModeToggle;

        private void OnEnable()
        {
            m_UseEnglishToggle.isOn = m_SystemProfile.Language == Meta.LANGUAGE.English;
            m_UseJapaneseToggle.isOn = m_SystemProfile.Language == Meta.LANGUAGE.Japanese;
            m_StartFromTitleToggle.isOn = m_SystemProfile.StartFromTitle;
            m_LowSpecModeToggle.isOn = m_SystemProfile.LowSpecMode;
        }

        public void Apply()
        {
            if (m_UseEnglishToggle.isOn)
            {
                m_SystemProfile.Language = Meta.LANGUAGE.English;
            }

            if (m_UseJapaneseToggle.isOn)
            {
                m_SystemProfile.Language = Meta.LANGUAGE.Japanese;
            }

            m_SystemProfile.StartFromTitle = m_StartFromTitleToggle.isOn;
            m_SystemProfile.LowSpecMode = m_LowSpecModeToggle.isOn;
        }
    }
}

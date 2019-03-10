using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Develop.Debug
{
    public class DebugCanvas2 : SerializedMonoBehaviour
    {
        [OdinSerialize] Profile.PlayerProfile m_PlayerProfile;
        [OdinSerialize] Text m_Text;

        private void Update()
        {
            m_Text.text = m_PlayerProfile.PlayerName;
        }
    }
}

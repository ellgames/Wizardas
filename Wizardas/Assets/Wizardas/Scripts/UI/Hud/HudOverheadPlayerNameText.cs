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
    public class HudOverheadPlayerNameText : SerializedMonoBehaviour
    {
        [OdinSerialize] EllGames.Assets.OverheadTextTarget m_OverheadTextTarget;
        [OdinSerialize] Profile.PlayerProfile m_PlayerProfile;

        private void Awake()
        {
            m_OverheadTextTarget.OverheadText = m_PlayerProfile.PlayerName;
        }
    }
}

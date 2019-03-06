﻿using System.Collections;
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
    public class HudPlayerNameText : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.PlayerProfile m_PlayerProfile;

        Text m_Text;

        private void Awake()
        {
            m_Text = GetComponent<Text>();
        }

        private void Update()
        {
            Debug.Assert(m_Text != null);
            Debug.Assert(m_PlayerProfile != null);

            m_Text.text = m_PlayerProfile.PlayerName;
        }
    }
}

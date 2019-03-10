using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Event
{
    public class RenameEvent : EventBase
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.PlayerProfile m_PlayerProfile;
        [OdinSerialize, Required] Text m_Text;

        public override void Invoke()
        {
            base.Invoke();

            m_PlayerProfile.PlayerName = m_Text.text;
        }
    }
}

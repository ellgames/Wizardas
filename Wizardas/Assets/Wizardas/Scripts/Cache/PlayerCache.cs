using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Cache
{
    [CreateAssetMenu(menuName = "Profile/PlayerCache", fileName = "PlayerCache")]
    public class PlayerCache : SerializedMonoBehaviour, Save.ISavable
    {
        void Save.ISavable.Save()
        {
            ES2.Save(m_PlayerName, "PlayerProfile/PlayerName");
        }

        void Save.ISavable.Load()
        {
            m_PlayerName = ES2.Load<string>("PlayerProfile/PlayerName");
        }

        [OdinSerialize] string m_PlayerName;
        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }
    }
}
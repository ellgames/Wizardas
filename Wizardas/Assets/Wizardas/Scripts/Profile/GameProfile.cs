using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Profile
{
    [CreateAssetMenu(menuName = "Profile/GameProfile", fileName = "GameProfile")]
    public class GameProfile : SerializedScriptableObject
    {
        [OdinSerialize] Meta.GAME_DIFFICULTY m_GameDifficulty;
        public Meta.GAME_DIFFICULTY GameDifficulty
        {
            get { return m_GameDifficulty; }
        }

        [OdinSerialize] Meta.GAME_MODE m_GameMode;
        public Meta.GAME_MODE GameMode
        {
            get { return m_GameMode; }
        }
    }
}
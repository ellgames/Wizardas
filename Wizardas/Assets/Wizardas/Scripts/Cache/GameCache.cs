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
    [CreateAssetMenu(menuName = "Profile/GameCache", fileName = "GameCache")]
    public class GameCache : SerializedMonoBehaviour, Save.ISavable
    {
        void Save.ISavable.Save()
        {
            ES2.Save(m_GameDifficulty, "GameProfile/GameDifficulty");
            ES2.Save(m_GameMode, "GameProfile/GameMode");
        }

        void Save.ISavable.Load()
        {
            m_GameDifficulty = ES2.Load<Meta.GAME_DIFFICULTY>("GameProfile/GameDifficulty");
            m_GameMode = ES2.Load<Meta.GAME_MODE>("GameProfile/GameMode");
        }

        [OdinSerialize] Meta.GAME_DIFFICULTY m_GameDifficulty;
        public Meta.GAME_DIFFICULTY GameDifficulty
        {
            get { return m_GameDifficulty; }
            set { m_GameDifficulty = value; }
        }

        [OdinSerialize] Meta.GAME_MODE m_GameMode;
        public Meta.GAME_MODE GameMode
        {
            get { return m_GameMode; }
            set { m_GameMode = value; }
        }
    }
}
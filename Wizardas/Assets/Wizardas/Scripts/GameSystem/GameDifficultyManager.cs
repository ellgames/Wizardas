using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem
{
    public class GameDifficultyManager : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.GameProfile m_LatestGameProfile;

        [Title("Settings")]
        [OdinSerialize] Dictionary<Meta.GAME_DIFFICULTY, GameObject> m_Spawners = new Dictionary<Meta.GAME_DIFFICULTY, GameObject>();

        public void Initialize()
        {
            foreach (var pair in m_Spawners)
            {
                m_Spawners[pair.Key].gameObject.SetActive(false);
            }
        }

        private void Awake()
        {
            if (m_Spawners == null) return;

            Initialize();
            m_Spawners[m_LatestGameProfile.GameDifficulty].SetActive(true);
        }
    }
}

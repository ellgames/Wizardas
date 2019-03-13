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
    public class GameAudioManager : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.GameProfile m_LatestGameProfile;

        [Title("Settings")]
        [OdinSerialize] GameObject m_AudioSource_NotDangerMode;
        [OdinSerialize] GameObject m_AudioSource_DangerMode;

        public void Initialize()
        {
            m_AudioSource_NotDangerMode.gameObject.SetActive(false);
            m_AudioSource_DangerMode.gameObject.SetActive(false);
        }

        private void Awake()
        {
            Initialize();

            switch (m_LatestGameProfile.GameDifficulty)
            {
                case Meta.GAME_DIFFICULTY.Novice:
                    m_AudioSource_NotDangerMode.gameObject.SetActive(true);
                    break;
                case Meta.GAME_DIFFICULTY.Hard:
                    m_AudioSource_NotDangerMode.gameObject.SetActive(true);
                    break;
                case Meta.GAME_DIFFICULTY.Veteran:
                    m_AudioSource_NotDangerMode.gameObject.SetActive(true);
                    break;
                case Meta.GAME_DIFFICULTY.Master:
                    m_AudioSource_DangerMode.gameObject.SetActive(true);
                    break;
                case Meta.GAME_DIFFICULTY.Impossible:
                    m_AudioSource_DangerMode.gameObject.SetActive(true);
                    break;
            }
        }
    }
}

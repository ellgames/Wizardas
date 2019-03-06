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
    [CreateAssetMenu(menuName = "Profile/HitProfile", fileName = "HitProfile")]
    public class HitProfile : SerializedScriptableObject
    {
        [Title("Required")]
        [OdinSerialize, Required] SystemProfile m_SystemProfile;

        [Title("Combo")]
        [OdinSerialize] int m_HitCount;
        public int HitCount
        {
            get { return m_HitCount; }
        }

        /// <summary>
        /// プロファイルを初期化します。
        /// </summary>
        [Button("Initialize")]
        public void Initialize()
        {
            m_HitCount = 0;
        }

        /// <summary>
        /// ヒットカウントを加算します。
        /// </summary>
        [Button("Hit")]
        public bool AddHitCount()
        {
            m_HitCount++;

            return true;
        }

        public void ForcedSetHitCount(int count)
        {
            m_HitCount = count;
        }
    }
}
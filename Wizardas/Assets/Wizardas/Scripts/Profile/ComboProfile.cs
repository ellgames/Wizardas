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
    [CreateAssetMenu(menuName = "Profile/ComboProfile", fileName = "ComboProfile")]
    public class ComboProfile : SerializedScriptableObject
    {
        [Title("Combo")]
        [OdinSerialize] int m_ComboCount;
        public int ComboCount
        {
            get { return m_ComboCount; }
        }

        /// <summary>
        /// コンボを加算します。
        /// </summary>
        public bool AddComboCount()
        {
            m_ComboCount++;

            return true;
        }

        /// <summary>
        /// コンボを0にします。
        /// </summary>
        public void SetZeroCombo()
        {
            m_ComboCount = 0;
        }
    }
}
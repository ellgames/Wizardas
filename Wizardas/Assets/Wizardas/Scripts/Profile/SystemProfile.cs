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
    [CreateAssetMenu(menuName = "Profile/SystemProfile", fileName = "SystemProfile")]
    public class SystemProfile : SerializedScriptableObject
    {
        [Title("Meta")]
        [OdinSerialize] Meta.LANGUAGE m_Language = Meta.LANGUAGE.Japanese;
        public Meta.LANGUAGE Language
        {
            get { return m_Language; }
            set { m_Language = value; }
        }

        [OdinSerialize] bool m_Tutorial = true;
        public bool Tutorial
        {
            get { return m_Tutorial; }
            set { m_Tutorial = value; }
        }
    }
}
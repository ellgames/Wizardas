using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using EllGames.Wiz.Extension;

namespace EllGames.Wiz.Utility
{
    public class RandomActivator : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] List<GameObject> m_Activatables = new List<GameObject>();

        private void Awake()
        {
            if (m_Activatables == null) return;
            m_Activatables.GetAtRandom().SetActive(true);
        }
    }
}

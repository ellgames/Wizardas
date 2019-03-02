using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.DB
{
    [CreateAssetMenu(menuName = "DB/Status", fileName = "Status")]
    public class Status : SerializedScriptableObject
    {
        [Title("Basic")]
        [OdinSerialize] string m_ActorName = "ActorNameHere";
        public string ActorName
        {
            get { return m_ActorName; }
        }

        [Title("Spec")]
        [OdinSerialize] int m_MaxHP = 1000;
        public int MaxHP
        {
            get { return m_MaxHP; }
        }

        [OdinSerialize] int m_HP = 1000;
        public int HP
        {
            get { return m_HP; }
        }

        [OdinSerialize] int m_ATK = 1;
        public int ATK
        {
            get { return m_ATK; }
        }
    }
}
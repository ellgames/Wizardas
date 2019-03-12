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
    [CreateAssetMenu(menuName = "DB/Title", fileName = "Title")]
    public class Title : SerializedScriptableObject
    {
        [OdinSerialize] int m_ID;
        [OdinSerialize] string m_Text_Jpn;
        [OdinSerialize] string m_Text_Eng;
    }
}
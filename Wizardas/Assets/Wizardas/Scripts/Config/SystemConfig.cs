using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Config
{
    [CreateAssetMenu(menuName = "Config/SystemConfig", fileName = "SystemConfig")]
    public class SystemConfig : SerializedScriptableObject
    {
        [OdinSerialize, PreviewField] Sprite m_SelectionPointerSprite;
        public Sprite SelectionPointerSprite
        {
            get { return m_SelectionPointerSprite; }
        }
    }
}
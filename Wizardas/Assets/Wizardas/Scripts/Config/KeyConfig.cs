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
    [CreateAssetMenu(menuName = "Config/KeyConfig", fileName = "KeyConfig")]
    public class KeyConfig : SerializedScriptableObject
    {
        /// <summary>
        /// 0: マウス左ボタン, 1: マウス右ボタン
        /// </summary>
        [OdinSerialize] public int PlayerMoveMouseButton { get; set; } = 0;
        [OdinSerialize] public List<KeyCode> PlayerWalkTriggers = new List<KeyCode> { KeyCode.LeftShift, KeyCode.RightShift };
    }
}
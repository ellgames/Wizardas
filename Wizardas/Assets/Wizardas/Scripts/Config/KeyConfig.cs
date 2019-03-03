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
        [OdinSerialize] public KeyCode MoveForwardKey { get; set; } = KeyCode.W;
        [OdinSerialize] public KeyCode MoveLeftKey { get; set; } = KeyCode.A;
        [OdinSerialize] public KeyCode MoveBackwardKey { get; set; } = KeyCode.S;
        [OdinSerialize] public KeyCode MoveRightKey { get; set; } = KeyCode.D;
        [OdinSerialize] public KeyCode JumpKey { get; set; } = KeyCode.Space;
        [OdinSerialize] public List<KeyCode> WalkTriggers = new List<KeyCode> { KeyCode.LeftShift, KeyCode.RightShift };
    }
}
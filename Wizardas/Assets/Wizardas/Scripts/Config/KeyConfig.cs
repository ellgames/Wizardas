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
        [OdinSerialize] public KeyCode StopKey1 { get; set; } = KeyCode.LeftControl;
        [OdinSerialize] public KeyCode StopKey2 { get; set; } = KeyCode.RightControl;
        [OdinSerialize] public List<KeyCode> WalkTriggers = new List<KeyCode> { KeyCode.LeftShift, KeyCode.RightShift };
        [OdinSerialize] public KeyCode Skill1Key { get; set; } = KeyCode.I;
        [OdinSerialize] public KeyCode Skill2Key { get; set; } = KeyCode.J;
        [OdinSerialize] public KeyCode Skill3Key { get; set; } = KeyCode.K;
        [OdinSerialize] public KeyCode Skill4Key { get; set; } = KeyCode.L;
        [OdinSerialize] public KeyCode UpKey { get; set; } = KeyCode.UpArrow;
        [OdinSerialize] public KeyCode LeftKey { get; set; } = KeyCode.LeftArrow;
        [OdinSerialize] public KeyCode DownKey { get; set; } = KeyCode.DownArrow;
        [OdinSerialize] public KeyCode RightKey { get; set; } = KeyCode.RightArrow;
        [OdinSerialize] public KeyCode DecitionKey { get; set; } = KeyCode.Return;
        [OdinSerialize] public KeyCode CancelKey { get; set; } = KeyCode.Escape;
        [OdinSerialize] public KeyCode YesKey { get; set; } = KeyCode.Y;
    }
}
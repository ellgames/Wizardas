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
        [SerializeField] public KeyCode MoveForwardKey { get; set; } = KeyCode.W;
        [SerializeField] public KeyCode MoveLeftKey { get; set; } = KeyCode.A;
        [SerializeField] public KeyCode MoveBackwardKey { get; set; } = KeyCode.S;
        [SerializeField] public KeyCode MoveRightKey { get; set; } = KeyCode.D;
        [SerializeField] public KeyCode JumpKey { get; set; } = KeyCode.Space;
        [SerializeField] public KeyCode StopKey1 { get; set; } = KeyCode.LeftControl;
        [SerializeField] public KeyCode StopKey2 { get; set; } = KeyCode.RightControl;
        [SerializeField] public List<KeyCode> WalkTriggers = new List<KeyCode> { KeyCode.LeftShift, KeyCode.RightShift };
        [SerializeField] public KeyCode Skill1Key { get; set; } = KeyCode.I;
        [SerializeField] public KeyCode Skill2Key { get; set; } = KeyCode.J;
        [SerializeField] public KeyCode Skill3Key { get; set; } = KeyCode.K;
        [SerializeField] public KeyCode Skill4Key { get; set; } = KeyCode.L;
        [SerializeField] public KeyCode Skill5Key { get; set; } = KeyCode.H;
        [SerializeField] public KeyCode UpKey { get; set; } = KeyCode.UpArrow;
        [SerializeField] public KeyCode LeftKey { get; set; } = KeyCode.LeftArrow;
        [SerializeField] public KeyCode DownKey { get; set; } = KeyCode.DownArrow;
        [SerializeField] public KeyCode RightKey { get; set; } = KeyCode.RightArrow;
        [SerializeField] public KeyCode DecitionKey { get; set; } = KeyCode.Return;
        [SerializeField] public KeyCode CancelKey { get; set; } = KeyCode.Escape;
        [SerializeField] public KeyCode YesKey { get; set; } = KeyCode.Y;
    }
}
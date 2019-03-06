using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Develop.Debug
{
    public class DebugCanvas : SerializedMonoBehaviour
    {
        [Title("Common Reference")]
        [OdinSerialize] GameSystem.Actor.Status m_PlayerStatus;
        [OdinSerialize] Rigidbody m_PlayerRigidbody;
        [OdinSerialize] GameSystem.Actor.PlayerBehaviour.PlayerMove m_PlayerMove;

        [Title("UI Reference")]
        [OdinSerialize] Text m_RunSpeedText;
        [OdinSerialize] Text m_WalkSpeedText;
        [OdinSerialize] Text m_PlayerVelocityText;
        [OdinSerialize] Text m_RigidbodyVelocityText;
        [OdinSerialize] Text m_DeltaTimeText;
        [OdinSerialize] Text m_ElapsedTimeText;

        float m_ElapsedTime;

        private void Update()
        {
            m_RunSpeedText.text = "RunSpeed: " + m_PlayerStatus.RunSpeed.ToString();
            m_WalkSpeedText.text = "WalkSpeed: " + m_PlayerStatus.WalkSpeed.ToString();
            m_PlayerVelocityText.text = "PlayerVelocity: " + "(" + ((int)(m_PlayerMove.Velocity().x)).ToString() + ", " + ((int)(m_PlayerMove.Velocity().y)).ToString() + ", " + ((int)(m_PlayerMove.Velocity().z)).ToString() + ")";
            m_RigidbodyVelocityText.text = "RigidbodyVelocity: " + "(" + ((int)(m_PlayerRigidbody.velocity.x)).ToString() + ", " + ((int)(m_PlayerRigidbody.velocity.y)).ToString() + ", " + ((int)(m_PlayerRigidbody.velocity.z)).ToString() + ")";
            m_DeltaTimeText.text = "DeltaTime: " + Time.deltaTime.ToString();
            m_ElapsedTimeText.text = "ElapsedTime: " + m_ElapsedTime.ToString();

            m_ElapsedTime += Time.deltaTime;
        }
    }
}

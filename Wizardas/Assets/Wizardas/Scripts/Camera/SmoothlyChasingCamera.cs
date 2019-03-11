using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class SmoothlyChasingCamera : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] Transform m_Chased;
        [OdinSerialize] Transform m_Focused;
        [OdinSerialize] float m_Speed = 0.125f;

        [Title("Read Only")]
        [OdinSerialize, ReadOnly] Vector3 m_Offset;

        [Button("Focus")]
        public void Focus()
        {
            transform.LookAt(m_Focused);
        }

        private void Awake()
        {
            Focus();
            m_Offset = transform.position - m_Chased.position;
        }

        private void FixedUpdate()
        {
            var desiredPosition = m_Chased.position + m_Offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, m_Speed);
            transform.position = smoothedPosition;
        }
    }
}
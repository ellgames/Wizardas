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
    public class TitleCamera : SerializedMonoBehaviour
    {
        enum STATE
        {
            Accelerating,
            Decelerating,
            Constant
        }

        [OdinSerialize] Transform m_Focus;
        [OdinSerialize] float m_ShiftMoveDuration = 1f;
        [OdinSerialize] float m_ConstantMoveDuration = 1f;
        [OdinSerialize] float m_RotationAngle = 45f;
        [OdinSerialize] float m_AngleSpeed = 0.1f;

        bool m_ReverseMove = false;

        [OdinSerialize, ReadOnly] float m_ShiftTimeElapsed;
        [OdinSerialize, ReadOnly] float m_ConstantTimeElapsed;
        [OdinSerialize, ReadOnly] STATE m_State = STATE.Accelerating;

        Vector3 ForwardAxis() => Vector3.down;
        Vector3 ReverseAxis() => Vector3.up;

        private void Update()
        {
            switch (m_State)
            {
                case STATE.Accelerating:
                    m_ConstantTimeElapsed = 0f;
                    m_ShiftTimeElapsed += Time.deltaTime;
                    if (m_ShiftTimeElapsed >= m_ShiftMoveDuration) m_State = STATE.Constant;
                    break;
                case STATE.Constant:
                    m_ShiftTimeElapsed = 0f;
                    m_ConstantTimeElapsed += Time.deltaTime;
                    if (m_ConstantTimeElapsed >= m_ConstantMoveDuration) m_State = STATE.Decelerating;
                    break;
                case STATE.Decelerating:
                    m_ConstantTimeElapsed = 0f;
                    m_ShiftTimeElapsed += Time.deltaTime;
                    if (m_ShiftTimeElapsed >= m_ShiftMoveDuration)
                    {
                        m_State = STATE.Accelerating;
                        m_ReverseMove = !m_ReverseMove;
                    }
                    break;
            }
        }

        private void FixedUpdate()
        {
            var angleSpeed = 0f;

            switch (m_State)
            {
                case STATE.Accelerating:
                    angleSpeed = Mathf.Lerp(0f, m_AngleSpeed, m_ShiftTimeElapsed / m_ShiftMoveDuration);
                    break;
                case STATE.Constant:
                    m_ShiftTimeElapsed = 0f;
                    angleSpeed = m_AngleSpeed;
                    break;
                case STATE.Decelerating:
                    angleSpeed = Mathf.Lerp(m_AngleSpeed, 0f, m_ShiftTimeElapsed / m_ShiftMoveDuration);
                    break;
            }

            var axis = m_ReverseMove ? ReverseAxis() : ForwardAxis();
            transform.RotateAround(m_Focus.position, axis, angleSpeed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Actor.PlayerBehaviour
{
    public class PlayerMove : SerializedMonoBehaviour
    {
        enum STATE
        {
            Idling,
            Walking,
            Running
        }

        [Title("Required")]
        [OdinSerialize, Required] Rigidbody m_Rigidbody;
        [OdinSerialize, Required] Config.KeyConfig m_KeyConfig;
        [OdinSerialize, Required] Status m_Status;

        [Title("Animation")]
        [OdinSerialize] bool m_UsingAnimation = false;
        [OdinSerialize, EnableIf("m_UsingAnimation")] Animator m_Animator;
        [OdinSerialize, EnableIf("m_UsingAnimation")] string m_RunAnimationName;
        [OdinSerialize, EnableIf("m_UsingAnimation")] string m_WalkAnimationName;

        [Title("Footstep")]
        [OdinSerialize] bool m_UsingFootstep = false;
        [OdinSerialize, EnableIf("m_UsingFootstep")] Audio.SEPlayer m_SEPlayer;
        [OdinSerialize, EnableIf("m_UsingFootstep")] AudioClip m_Footstep;
        [OdinSerialize, EnableIf("m_UsingFootstep")] float m_VolumeScale = 0.8f;
        [OdinSerialize, EnableIf("m_UsingFootstep")] float m_RunFootstepInterval = 0.3f;
        [OdinSerialize, EnableIf("m_UsingFootstep")] float m_WalkFootstepInterval = 0.5f;
        float m_FootstepDuration;

        [Title("Readonly")]
        [OdinSerialize, ReadOnly] bool m_Movable = true;
        [OdinSerialize, ReadOnly] STATE m_State = STATE.Idling;

        #region Functions

        Vector3 Forward() => Vector3.forward;
        Vector3 Left() => Vector3.left;
        Vector3 Backward() => Vector3.back;
        Vector3 Right() => Vector3.right;
        float ForwardAngle() => 0f;
        float LeftAngle() => 270f;
        float BackwardAngle() => 180f;
        float RightAngle() => 90f;

        Vector3 MoveDirection()
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(m_KeyConfig.MoveForwardKey)) direction += Forward();
            if (Input.GetKey(m_KeyConfig.MoveLeftKey)) direction += Left();
            if (Input.GetKey(m_KeyConfig.MoveBackwardKey)) direction += Backward();
            if (Input.GetKey(m_KeyConfig.MoveRightKey)) direction += Right();

            return direction.normalized;
        }

        float MoveSpeed()
        {
            switch (m_State)
            {
                default:
                    return 0f;
                case STATE.Idling:
                    return 0f;
                case STATE.Walking:
                    return m_Status.WalkSpeed;
                case STATE.Running:
                    return m_Status.RunSpeed;
            }
        }

        public Vector3 Velocity()
        {
            if (Input.GetKey(m_KeyConfig.StopKey1) || Input.GetKey(m_KeyConfig.StopKey1)) return new Vector3(0f, m_Rigidbody.velocity.y, 0f);

            var velocity = MoveDirection() * MoveSpeed();   // Rigidbody.velocityはフレームなどに依存しないので、Time.deltaTimeを掛ける必要なはない
            velocity.y = m_Rigidbody.velocity.y;
            return velocity;
        }

        #endregion

        [Button("Allow Move")]
        public void AllowMove()
        {
            m_Movable = true;
        }

        [Button("Disallow Move")]
        public void DisallowMove()
        {
            m_Movable = false;
            m_State = STATE.Idling;

            if (m_UsingAnimation)
            {
                Debug.Assert(m_Animator != null);
                m_Animator.SetBool(m_RunAnimationName, false);
                m_Animator.SetBool(m_WalkAnimationName, false);
            }
        }

        void UpdateState()
        {
            if (Input.GetKey(m_KeyConfig.MoveForwardKey) || Input.GetKey(m_KeyConfig.MoveLeftKey) || Input.GetKey(m_KeyConfig.MoveBackwardKey) || Input.GetKey(m_KeyConfig.MoveRightKey))
            {
                m_State = STATE.Running;

                m_KeyConfig.WalkTriggers.ForEach(trigger =>
                {
                    if (Input.GetKey(trigger)) m_State = STATE.Walking;
                });
            }
            else
            {
                m_State = STATE.Idling;
            }
        }

        void UpdateVelocity()
        {
            m_Rigidbody.velocity = Velocity();
        }

        void UpdateEulerAngles()
        {
            if (m_State == STATE.Idling) return;

            int pressedMoveKeysCount = 0;
            float sumOfAngles = 0f;

            /* 以下の場合、0度を360度として演算する必要があるため処理を分岐します
             * ・前方移動と左方移動のみが入力されている場合
             * ・前方移動と左方移動と後方移動のみが入力されている場合 */
            if (Input.GetKey(m_KeyConfig.MoveForwardKey) && Input.GetKey(m_KeyConfig.MoveLeftKey) && !Input.GetKey(m_KeyConfig.MoveBackwardKey) && !Input.GetKey(m_KeyConfig.MoveRightKey))
            {
                // 前方移動の分
                sumOfAngles += 360f;
                pressedMoveKeysCount++;

                // 左方移動の分
                sumOfAngles += LeftAngle();
                pressedMoveKeysCount++;
            }
            else if (Input.GetKey(m_KeyConfig.MoveForwardKey) && Input.GetKey(m_KeyConfig.MoveLeftKey) && Input.GetKey(m_KeyConfig.MoveBackwardKey) && !Input.GetKey(m_KeyConfig.MoveRightKey))
            {
                // 前方移動の分
                sumOfAngles += 360f;
                pressedMoveKeysCount++;

                // 左方移動の分
                sumOfAngles += LeftAngle();
                pressedMoveKeysCount++;

                // 後方移動の分
                sumOfAngles += BackwardAngle();
                pressedMoveKeysCount++;
            }
            else
            {
                if (Input.GetKey(m_KeyConfig.MoveForwardKey))
                {
                    sumOfAngles += ForwardAngle();
                    pressedMoveKeysCount++;
                }

                if (Input.GetKey(m_KeyConfig.MoveLeftKey))
                {
                    sumOfAngles += LeftAngle();
                    pressedMoveKeysCount++;
                }

                if (Input.GetKey(m_KeyConfig.MoveBackwardKey))
                {
                    sumOfAngles += BackwardAngle();
                    pressedMoveKeysCount++;
                }

                if (Input.GetKey(m_KeyConfig.MoveRightKey))
                {
                    sumOfAngles += RightAngle();
                    pressedMoveKeysCount++;
                }
            }

            var fixedEulerAngles = m_Rigidbody.transform.eulerAngles;
            fixedEulerAngles.y = sumOfAngles / pressedMoveKeysCount;

            m_Rigidbody.transform.eulerAngles = fixedEulerAngles;
        }

        void UpdateAnimation()
        {
            Debug.Assert(m_Animator != null);

            switch (m_State)
            {
                default:
                    return;
                case STATE.Idling:
                    m_Animator.SetBool(m_RunAnimationName, false);
                    m_Animator.SetBool(m_WalkAnimationName, false);
                    return;
                case STATE.Running:
                    m_Animator.SetBool(m_RunAnimationName, true);
                    m_Animator.SetBool(m_WalkAnimationName, false);
                    return;
                case STATE.Walking:
                    m_Animator.SetBool(m_RunAnimationName, false);
                    m_Animator.SetBool(m_WalkAnimationName, true);
                    return;
            }
        }

        void UpdateFootstep()
        {
            Debug.Assert(m_SEPlayer != null);

            m_FootstepDuration -= Time.deltaTime;

            switch (m_State)
            {
                default:
                    return;
                case STATE.Idling:
                    return;
                case STATE.Running:
                    if (m_FootstepDuration <= 0f)
                    {
                        PlayFootstep();
                        m_FootstepDuration = m_RunFootstepInterval;
                    }
                    return;
                case STATE.Walking:
                    if (m_FootstepDuration <= 0f)
                    {
                        PlayFootstep();
                        m_FootstepDuration = m_WalkFootstepInterval;
                    }
                    return;
            }

            void PlayFootstep()
            {
                m_SEPlayer.PlayOneShot(m_Footstep, m_VolumeScale);
            }
        }

        private void Update()
        {
            if (!m_Movable) return;

            UpdateState();
            UpdateVelocity();
            UpdateEulerAngles();
            if (m_UsingAnimation) UpdateAnimation();
            if (m_UsingFootstep) UpdateFootstep();
        }
    }
}

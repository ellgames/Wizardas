using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using EllGames.Wiz.Extension;

namespace EllGames.Wiz.GameSystem.Actor.PlayerBehaviour
{
    public class WayPointMove : SerializedMonoBehaviour
    {
        enum STATE
        {
            Idling,
            Walking,
            Running
        }

        [Title("Required")]
        [OdinSerialize, Required] Rigidbody m_Rigidbody;
        [OdinSerialize, Required] Status m_Status;
        [OdinSerialize, Required] Config.KeyConfig m_KeyConfig;

        [Title("Readonly")]
        [OdinSerialize, ReadOnly] bool m_Movable = false;
        [OdinSerialize, ReadOnly] STATE m_State = STATE.Idling;

        [Title("Settings")]
        [OdinSerialize] float m_StoppingDistance = 0.3f;

        [Title("Raycast")]
        [OdinSerialize, ReadOnly] GameObject m_RaycastHitObject;
        [OdinSerialize, ReadOnly] Vector3? m_RaycastHitPosition;

        [Button("Allow Move")]
        public void AllowMove()
        {
            m_Movable = true;
        }

        [Button("Disallow Move")]
        public void DisallowMove()
        {
            Stop();
            m_Movable = false;
        }

        [Button("Stop")]
        public void Stop()
        {
            Initialize();
        }

        [Button("Stop Immediately")]
        public void StopImmediately()
        {
            Stop();
            m_Rigidbody.velocity = Vector3.zero;
        }

        public void Initialize()
        {
            m_RaycastHitObject = null;
            m_RaycastHitPosition = null;
        }

        void RayCast()
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                m_RaycastHitObject = hit.transform.gameObject;
                m_RaycastHitPosition = hit.point;
            }
        }

        Vector3 Destination() => m_RaycastHitPosition == null ? m_Rigidbody.transform.position : (Vector3)m_RaycastHitPosition;
        Vector3 MoveDirection() => (Destination() - m_Rigidbody.transform.position).Flatten().normalized;
        bool HasReachedDestination() => Math.HorizontalDistance(Destination(), m_Rigidbody.transform.position) <= m_StoppingDistance;

        void LookAtDestination()
        {
            m_Rigidbody.transform.LookAt(Destination().Flatten());
        }

        void UpdateState()
        {
            if (HasReachedDestination())
            {
                m_State = STATE.Idling;
            }
            else
            {
                m_State = STATE.Running;

                if (Input.GetKey(KeyCode.LeftShift)) m_State = STATE.Walking;
                /*
                m_KeyConfig.PlayerWalkTriggers.ForEach(trigger =>
                {
                    if (Input.GetKey(trigger)) m_State = STATE.Walking;
                });*/
            }
        }

        void UpdateVelocity()
        {
            Vector3 velocity;

            switch (m_State)
            {
                default:
                    velocity = Vector3.zero;
                    velocity.y = m_Rigidbody.velocity.y;
                    break;
                case STATE.Idling:
                    velocity = Vector3.zero;
                    velocity.y = m_Rigidbody.velocity.y;
                    break;
                case STATE.Walking:
                    LookAtDestination();
                    velocity = MoveDirection() * m_Status.WalkSpeed * Time.deltaTime;
                    velocity.y = m_Rigidbody.velocity.y;
                    break;
                case STATE.Running:
                    LookAtDestination();
                    velocity = MoveDirection() * m_Status.RunSpeed * Time.deltaTime;
                    velocity.y = m_Rigidbody.velocity.y;
                    break;
            }

            m_Rigidbody.velocity = velocity;
        }

        private void Update()
        {
            if (!m_Movable) return;

            Vector3 e = m_Rigidbody.transform.eulerAngles;
            e.x = 0f;
            e.z = 0f;
            m_Rigidbody.transform.eulerAngles = e;



            UpdateState();
            UpdateVelocity();

            if (Input.GetMouseButton(0)) RayCast();
            //if (Input.GetMouseButton(m_KeyConfig.PlayerMoveMouseButton)) RayCast();
        }
    }
}
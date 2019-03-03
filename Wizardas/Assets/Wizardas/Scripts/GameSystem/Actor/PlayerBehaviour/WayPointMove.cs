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
        [OdinSerialize, Required] CharacterController m_CharacterController;
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

        Vector3 Destination() => m_RaycastHitPosition == null ? m_CharacterController.transform.position : (Vector3)m_RaycastHitPosition;
        Vector3 MoveDirection() => (Destination().Flatten() - m_CharacterController.transform.position.Flatten()).normalized;
        bool HasReachedDestination() => Math.HorizontalDistance(Destination(), m_CharacterController.transform.position) <= m_StoppingDistance;

        void LookAtDestination()
        {
            m_CharacterController.transform.LookAt(Destination().Flatten());
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

                m_KeyConfig.PlayerWalkTriggers.ForEach(trigger =>
                {
                    if (Input.GetKey(trigger)) m_State = STATE.Walking;
                });
            }
        }

        private void FixedUpdate()
        {
            if (!m_Movable) return;

            switch (m_State)
            {
                case STATE.Idling:
                    break;
                case STATE.Walking:
                    LookAtDestination();
                    m_CharacterController.Move(MoveDirection() * m_Status.WalkSpeed);
                    break;
                case STATE.Running:
                    LookAtDestination();
                    m_CharacterController.Move(MoveDirection() * m_Status.RunSpeed);
                    break;
            }
        }

        private void Update()
        {
            if (!m_Movable) return;

            UpdateState();

            if (Input.GetMouseButton(m_KeyConfig.PlayerMoveMouseButton)) RayCast();
        }
    }
}

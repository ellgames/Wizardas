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
    public class TPSCamera : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] bool m_IsChasingPlayer = true;
        [OdinSerialize] FreeLookSettings m_FreeLookSettings = new FreeLookSettings();
        [OdinSerialize] ZoomSettings m_ZoomSettings = new ZoomSettings();

        [Title("Reference")]
        [OdinSerialize, Required] Transform m_Focus;

        Vector3 m_InitialPosition;
        Vector3 m_LatestCenterPositionOfPlayer;

        /// <summary>
        /// カメラの位置関係を初期化します。
        /// </summary>
        public void Initialize()
        {
            transform.position = m_InitialPosition;
            transform.LookAt(m_Focus.position);
            m_LatestCenterPositionOfPlayer = m_Focus.position;
        }

        void RatateAroundTarget()
        {
            if (!Input.GetMouseButton(1)) return;

            float horizontalDelta = Input.GetAxis("Mouse X");
            float verticalDelta = Input.GetAxis("Mouse Y");

            transform.RotateAround(m_Focus.position, Vector3.up, horizontalDelta * m_FreeLookSettings.FreeLookSpeed);
            transform.RotateAround(m_Focus.position, -transform.right, verticalDelta * m_FreeLookSettings.FreeLookSpeed);

            if (m_FreeLookSettings.RotationMinX <= transform.eulerAngles.x && transform.eulerAngles.x <= m_FreeLookSettings.RotationMaxX) return;

            transform.RotateAround(m_Focus.position, -transform.right, -verticalDelta * m_FreeLookSettings.FreeLookSpeed);
        }

        void Zoom()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            transform.position += transform.forward * scroll * m_ZoomSettings.ZoomSpeed;

            float distance = Vector3.Distance(transform.position, m_Focus.position);

            if (m_ZoomSettings.ViewRangeMin <= distance && distance <= m_ZoomSettings.ViewRangeMax) return;

            transform.position -= transform.forward * scroll * m_ZoomSettings.ZoomSpeed;
        }

        void FixPosition()
        {
            if (m_IsChasingPlayer) transform.position += m_Focus.position - m_LatestCenterPositionOfPlayer;
        }

        /// <summary>
        /// 固定カメラモードに変更します。
        /// </summary>
        public void EnableFixedCameraMode()
        {
            m_ZoomSettings.ZoomLock = true;
            m_FreeLookSettings.FreeLookLock = true;
            m_IsChasingPlayer = false;
        }

        /// <summary>
        /// 固定カメラモードを解除します。
        /// </summary>
        public void DisableFixedCameraMode()
        {
            m_ZoomSettings.ZoomLock = false;
            m_FreeLookSettings.FreeLookLock = false;
            m_IsChasingPlayer = true;
        }

        public void Awake()
        {
            m_InitialPosition = transform.position;
            Initialize();
        }

        void Update()
        {
            FixPosition();

            if (!m_FreeLookSettings.FreeLookLock) RatateAroundTarget();
            if (!m_ZoomSettings.ZoomLock) Zoom();

            m_LatestCenterPositionOfPlayer = m_Focus.position;
        }
    }
}

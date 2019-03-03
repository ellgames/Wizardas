using UnityEngine;

namespace EllGames.Wiz.Camera
{
    [System.Serializable]
    public class FreeLookSettings
    {
        [SerializeField] bool m_FreeLookLock;
        public bool FreeLookLock
        {
            get { return m_FreeLookLock; }
            set { m_FreeLookLock = value; }
        }

        [SerializeField] float m_FreeLookSpeed = 1.0f;
        public float FreeLookSpeed
        {
            get { return m_FreeLookSpeed; }
        }

        [SerializeField] float m_RotationMinX = 0.0f;
        public float RotationMinX
        {
            get { return m_RotationMinX; }
        }

        [SerializeField] float m_RotationMaxX = 80.0f;
        public float RotationMaxX
        {
            get { return m_RotationMaxX; }
        }
    }
}
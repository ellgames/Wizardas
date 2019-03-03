using UnityEngine;

namespace EllGames.Wiz.Camera
{
    [System.Serializable]
    public class ZoomSettings
    {
        [SerializeField] bool m_ZoomLock;
        public bool ZoomLock
        {
            get { return m_ZoomLock; }
            set { m_ZoomLock = value; }
        }

        [SerializeField] float m_ZoomSpeed = 10.0f;
        public float ZoomSpeed
        {
            get { return m_ZoomSpeed; }
        }

        [SerializeField] float m_ViewRangeMin = 2.5f;
        public float ViewRangeMin
        {
            get { return m_ViewRangeMin; }
        }

        [SerializeField] float m_ViewRangeMax = 15.0f;
        public float ViewRangeMax
        {
            get { return m_ViewRangeMax; }
        }
    }
}
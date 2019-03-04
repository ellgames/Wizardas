using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EllOverheadText
{
    public class OverheadTextTarget : MonoBehaviour
    {
        [SerializeField] GameObject m_OverheadTextPrefab;
        [SerializeField] string m_OverheadText = "Enter overhead text here";
        public string OverheadText
        {
            get { return m_OverheadText; }
            set { m_OverheadText = value; }
        }

        [SerializeField] Vector3 m_Offset;

        OverheadTextManager m_OverheadTextManager;

        public void Unattach()
        {
            Destroy(this);
        }

        private void Awake()
        {
            m_OverheadTextManager = FindObjectOfType<OverheadTextManager>();

            if (m_OverheadTextPrefab == null)
            {
                m_OverheadTextManager.Assign(this, m_Offset, null);
            }
            else
            {
                m_OverheadTextManager.Assign(this, m_Offset, m_OverheadTextPrefab);
            }
        }
    }
}
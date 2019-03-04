using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EllOverheadText
{
    public class OverheadText : MonoBehaviour
    {
        [SerializeField] OverheadTextTarget m_Target;
        [SerializeField] Vector3 m_Offset;

        private RectTransform m_RectTransform;
        private Text m_Text;

        void ChaseTarget()
        {
            m_RectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, m_Target.transform.position + m_Offset);
        }

        public void Assign(OverheadTextTarget target, Vector3 offset)
        {
            m_Target = target;
            m_Offset = offset;
            m_Text.text = target.OverheadText;
            ChaseTarget();
        }

        void Awake()
        {
            m_RectTransform = GetComponent<RectTransform>();
            m_Text = GetComponent<Text>();
        }

        void Update()
        {
            if (m_Target == null)
            {
                Destroy(gameObject);
                return;
            }

            ChaseTarget();
        }
    }
}
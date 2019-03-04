using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EllOverheadText
{
    public class OverheadTextManager : MonoBehaviour
    {
        [SerializeField] GameObject m_DefaultOverheadTextPrefab;

        public void Assign(OverheadTextTarget target, Vector3 offset, GameObject overheadTextPrefab = null)
        {
            Debug.Assert(m_DefaultOverheadTextPrefab != null);

            //var overheadText = Instantiate(overheadTextPrefab != null ? overheadTextPrefab : m_DefaultOverheadTextPrefab, transform);
            var overheadText = Instantiate(overheadTextPrefab ?? m_DefaultOverheadTextPrefab, transform);
            overheadText.GetComponent<OverheadText>().Assign(target, offset);
        }
    }
}
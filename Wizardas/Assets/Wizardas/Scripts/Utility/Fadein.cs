using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Utility
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Fadein : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] float m_Duration = 1f;

        MeshRenderer m_MeshRenderer;
        float m_TimeElapsed;

        void ChangeAlpha(float alpha)
        {
            var buf = m_MeshRenderer.material.color;
            buf.a = alpha;
            m_MeshRenderer.material.color = buf;
        }

        void Transparentize()
        {
            ChangeAlpha(1f);
        }

        void Opaque()
        {
            ChangeAlpha(0f);
        }

        private void Awake()
        {
            m_TimeElapsed = 0f;
            m_MeshRenderer = GetComponent<MeshRenderer>();
            Transparentize();
        }

        private void Update()
        {
            if (m_TimeElapsed >= m_Duration)
            {
                Opaque();
                enabled = false;
            }

            ChangeAlpha(m_TimeElapsed / m_Duration);

            m_TimeElapsed += Time.deltaTime;
        }
    }
}

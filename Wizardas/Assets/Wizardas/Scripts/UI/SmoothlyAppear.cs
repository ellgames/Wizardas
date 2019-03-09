using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI
{
    public class SmoothlyAppear : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] float m_Duration = 0.1f;
        [OdinSerialize] Transform m_StartPoint;

        Vector3 m_DefaultLocalScale;
        Vector3 m_DefaultPosition;


        private void OnEnable()
        {
            m_DefaultPosition = transform.position;
            transform.position = m_StartPoint.position;
            m_DefaultLocalScale = transform.localScale;
            StartCoroutine(SmoothlyAppearCoroutine(m_Duration));
        }

        public void DeactivateSmoothly()
        {
            StartCoroutine(SmoothlyDisappearCoroutine(m_Duration));
        }

        IEnumerator SmoothlyAppearCoroutine(float duration)
        {
            var timeElapsed = 0f;

            while (true)
            {
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= duration) break;

                transform.localScale = m_DefaultLocalScale * (timeElapsed / duration);
                transform.position += (m_DefaultPosition - m_StartPoint.position) * (Time.deltaTime / duration);

                yield return null;
            }

            transform.localScale = m_DefaultLocalScale;
            transform.position = m_DefaultPosition;
        }

        IEnumerator SmoothlyDisappearCoroutine(float duration)
        {
            var timeElapsed = 0f;

            while (true)
            {
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= duration) break;

                transform.localScale = m_DefaultLocalScale * (1f - timeElapsed / duration);
                transform.position -= (m_DefaultPosition - m_StartPoint.position) * (Time.deltaTime / duration);

                yield return null;
            }

            transform.localScale = m_DefaultLocalScale;
            transform.position = m_StartPoint.position;
            gameObject.SetActive(false);
            transform.position = m_DefaultPosition;
        }
    }
}

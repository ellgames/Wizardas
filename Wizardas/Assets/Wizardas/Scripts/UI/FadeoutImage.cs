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
    public class FadeoutImage : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] float m_Duration = 0.1f;

        Image m_Image;

        float defaultAlpha;

        void SetAlpha(float alpha)
        {
            var color = m_Image.color;
            color.a = alpha;
            m_Image.color = color;
        }

        private void Awake()
        {
            m_Image = GetComponent<Image>();
            defaultAlpha = m_Image.color.a;
        }

        public void Fadeout()
        {
            StartCoroutine(FadeoutCoroutine(m_Duration));
        }

        IEnumerator FadeoutCoroutine(float duration)
        {
            var timeElapsed = 0f;

            while (true)
            {
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= duration) break;

                SetAlpha(defaultAlpha - timeElapsed / duration);

                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}

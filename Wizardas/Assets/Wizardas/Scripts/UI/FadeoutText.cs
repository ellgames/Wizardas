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
    public class FadeoutText : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] float m_Duration = 0.1f;

        Text m_Text;

        void SetAlpha(float alpha)
        {
            var color = m_Text.color;
            color.a = alpha;
            m_Text.color = color;
        }

        private void Awake()
        {
            m_Text = GetComponent<Text>();
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

                SetAlpha(1f - timeElapsed / duration);

                yield return null;
            }

            gameObject.SetActive(false);
        }
    }
}

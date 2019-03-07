using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI.Hud
{
    [RequireComponent(typeof(Image))]
    public class HudOverlay : HudComponent
    {
        [Title("Settings")]
        [OdinSerialize] float m_TransitionDuration = 1f;
        [OdinSerialize] float m_AlphaMin = 0f;
        [OdinSerialize] float m_AlphaMax = 0.5f;

        Image m_Image;

        public void SetAlpha(float alpha)
        {
            var color = m_Image.color;
            color.a = alpha;
            m_Image.color = color;
        }

        public void Enable()
        {
            m_Image.enabled = true;
        }

        public void Disable()
        {
            m_Image.enabled = false;
        }

        public void EnableSmoothly()
        {
            Enable();
            StartCoroutine(ChangeAlphaSmoothly(m_TransitionDuration, m_AlphaMin, m_AlphaMax));
        }

        public void DisableSmoothly()
        {
            StartCoroutine(ChangeAlphaSmoothly(m_TransitionDuration, m_AlphaMax, m_AlphaMin, () => Disable()));
        }

        private void Awake()
        {
            m_Image = GetComponent<Image>();
        }

        IEnumerator ChangeAlphaSmoothly(float duration, float startAlpha, float endAlpha, System.Action OnChanged = null)
        {
            SetAlpha(startAlpha);

            var timeElapsed = 0f;
            var currentAlpha = m_Image.color.a;

            while (timeElapsed <= duration)
            {
                if (OutOfRange()) break;

                yield return null;

                timeElapsed += Time.deltaTime;

                float nextAlpha = Mathf.Abs(endAlpha - startAlpha);

                if (endAlpha > startAlpha)
                {
                    nextAlpha *= timeElapsed / duration;
                }
                else
                {
                    nextAlpha *= 1f - timeElapsed / duration;
                }

                SetAlpha(nextAlpha);

                bool OutOfRange()
                {
                    if (startAlpha < endAlpha)
                    {
                        return !(startAlpha <= currentAlpha && currentAlpha <= endAlpha);
                    }
                    else
                    {
                        return !(endAlpha <= currentAlpha && currentAlpha <= startAlpha);
                    }
                }
            }

            SetAlpha(endAlpha);
            if (OnChanged != null) OnChanged.Invoke();
        }
    }
}

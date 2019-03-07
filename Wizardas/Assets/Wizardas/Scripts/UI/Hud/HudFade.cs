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
    public class HudFade : HudComponent
    {
        const float ALPHA_MIN = 0f;
        const float ALPHA_MAX = 0f;

        enum FADE_TYPE
        {
            FadeIn,
            FadeOut
        }

        [Title("Settings")]
        [OdinSerialize] FADE_TYPE m_FadeType;
        [OdinSerialize] float m_Duration = 1f;

        [Title("Callback")]
        [OdinSerialize] UnityEvent m_OnFadeFinished = new UnityEvent();

        Image m_Image;
        float m_TimeElapsed;

        void ChangeAlpha(float alpha)
        {
            var current = m_Image.color;
            current.a = alpha;
            m_Image.color = current;
        }

        private void Awake()
        {
            m_Image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            m_TimeElapsed = 0f;

            switch (m_FadeType)
            {
                case FADE_TYPE.FadeIn:
                    ChangeAlpha(ALPHA_MAX);
                    break;
                case FADE_TYPE.FadeOut:
                    ChangeAlpha(ALPHA_MIN);
                    break;
            }
        }

        private void Update()
        {
            m_TimeElapsed += Time.deltaTime;

            switch (m_FadeType)
            {
                case FADE_TYPE.FadeIn:
                    ChangeAlpha(1f - m_TimeElapsed / m_Duration);
                    break;
                case FADE_TYPE.FadeOut:
                    ChangeAlpha(m_TimeElapsed / m_Duration);
                    break;
            }

            if (m_TimeElapsed >= m_Duration)
            {
                m_OnFadeFinished.Invoke();
                m_TimeElapsed = m_Duration;
            }
        }
    }
}

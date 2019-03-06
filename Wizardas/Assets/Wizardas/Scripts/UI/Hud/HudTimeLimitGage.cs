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
    public class HudTimeLimitGage : HudComponent
    {
        const int SECONS_PER_MINUTES = 60;

        [Title("Required")]
        [OdinSerialize, Required] Utility.Timer m_Timer;
        [OdinSerialize, Required] Image m_GreenFillImage;
        [OdinSerialize, Required] Image m_YellowFillImage;
        [OdinSerialize, Required] Image m_RedFillImage;

        void DeactivateAllFillImages()
        {
            m_GreenFillImage.gameObject.SetActive(false);
            m_YellowFillImage.gameObject.SetActive(false);
            m_RedFillImage.gameObject.SetActive(false);
        }

        private void Update()
        {
            Debug.Assert(m_GreenFillImage != null);
            Debug.Assert(m_YellowFillImage != null);
            Debug.Assert(m_RedFillImage != null);
            Debug.Assert(m_Timer != null);

            var fillAmount = m_Timer.Seconds / SECONS_PER_MINUTES;

            if (m_Timer.Minutes == 0)
            {
                DeactivateAllFillImages();
                m_RedFillImage.gameObject.SetActive(true);
                m_RedFillImage.fillAmount = fillAmount;
            }

            if (m_Timer.Minutes == 1)
            {
                DeactivateAllFillImages();
                m_YellowFillImage.gameObject.SetActive(true);
                m_YellowFillImage.fillAmount = fillAmount;
            }

            if (m_Timer.Minutes >= 2) 
            {
                DeactivateAllFillImages();
                m_GreenFillImage.gameObject.SetActive(true);
                m_GreenFillImage.fillAmount = fillAmount;
            }
        }
    }
}

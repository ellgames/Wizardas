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
    public class HudHPGage : HudComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Text m_HPText;
        [OdinSerialize, Required] Image m_FillImage;

        [Title("Settings")]
        [OdinSerialize] IHPWatch m_IHPWatch;

        private void Update()
        {
            Debug.Assert(m_HPText != null);
            Debug.Assert(m_FillImage != null);
            Debug.Assert(m_IHPWatch != null);

            m_HPText.text = m_IHPWatch.HP().ToString() + " / " + m_IHPWatch.MaxHP().ToString();
            m_FillImage.fillAmount = (float)m_IHPWatch.HP() / m_IHPWatch.MaxHP();
        }
    }
}

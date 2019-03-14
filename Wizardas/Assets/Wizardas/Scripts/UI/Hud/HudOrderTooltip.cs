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
    public class HudOrderTooltip : HudComponent
    {
        [Title("Required")]
        [OdinSerialize, Required] Text m_LabelText;
        [OdinSerialize, Required] Text m_DescriptionText;

        public void Assign(string label, string description)
        {
            m_LabelText.text = label;
            m_DescriptionText.text = description;
        }

        private void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}

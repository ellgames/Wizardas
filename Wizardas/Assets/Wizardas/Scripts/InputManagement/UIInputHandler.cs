using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.InputManagement
{
    public class UIInputHandler : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Config.KeyConfig m_KeyConfig;
        [OdinSerialize, Required] UI.Selection.UISelector m_UISelector;

        private void Update()
        {
            if ((Input.GetKeyDown(m_KeyConfig.UpKey) || Input.GetKeyDown(m_KeyConfig.MoveForwardKey) || Input.GetKeyDown(m_KeyConfig.Skill1Key)) ||
                (Input.GetKeyDown(m_KeyConfig.LeftKey) || Input.GetKeyDown(m_KeyConfig.MoveLeftKey) || Input.GetKeyDown(m_KeyConfig.Skill2Key)))
            {
                m_UISelector.SelectPrevious();
            }

            if ((Input.GetKeyDown(m_KeyConfig.DownKey) || Input.GetKeyDown(m_KeyConfig.MoveBackwardKey) || Input.GetKeyDown(m_KeyConfig.Skill3Key)) ||
                (Input.GetKeyDown(m_KeyConfig.RightKey) || Input.GetKeyDown(m_KeyConfig.MoveRightKey) || Input.GetKeyDown(m_KeyConfig.Skill4Key)))
            {
                m_UISelector.SelectNext();
            }

            if (Input.GetKeyDown(m_KeyConfig.DecitionKey) || Input.GetKeyDown(m_KeyConfig.JumpKey))
            {
                m_UISelector.Decide();
            }

            if (Input.GetKeyDown(m_KeyConfig.CancelKey))
            {
                m_UISelector.Cancel();
            }
        }
    }
}

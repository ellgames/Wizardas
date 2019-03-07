using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI.Selector
{
    [RequireComponent(typeof(Image))]
    public class Pointer : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Config.SystemConfig m_SystemConfig;

        [Title("Settings")]
        [OdinSerialize] bool m_DeactivateOnAwake = true;

        Image m_Image;

        private void Awake()
        {
            m_Image = GetComponent<Image>();
            m_Image.sprite = m_SystemConfig.SelectionPointerSprite;

            if (m_DeactivateOnAwake) gameObject.SetActive(false);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}

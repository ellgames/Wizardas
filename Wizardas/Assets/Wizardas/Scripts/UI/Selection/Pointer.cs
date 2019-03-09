using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI.Selection
{
    [RequireComponent(typeof(Image))]
    public class Pointer : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Config.SystemConfig m_SystemConfig;

        [Title("Reference")]
        [OdinSerialize] Image m_Image;

        [Title("Settings")]
        [OdinSerialize] bool m_DeactivateOnAwake = true;

        [Button("Pointer Graphic Update")]
        void PointerGraphicUpdate()
        {
            Debug.Assert(m_SystemConfig != null);
            Debug.Assert(m_Image != null);
            m_Image.sprite = m_SystemConfig.SelectionPointerSprite;
        }

        private void Awake()
        {
            if (m_DeactivateOnAwake) Deactivate();
        }

        private void Update()
        {
            PointerGraphicUpdate();
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

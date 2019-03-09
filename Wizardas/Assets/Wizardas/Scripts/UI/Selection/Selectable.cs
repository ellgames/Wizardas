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
    public class Selectable : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize] Pointer m_Pointer;

        [Title("Settings")]
        [OdinSerialize] UnityEvent m_OnDecided = new UnityEvent();

        [Title("Read Only")]
        [OdinSerialize, ReadOnly] bool m_IsSelected = false;
        public bool IsSelected
        {
            get { return m_IsSelected; }
        }

        public void Select()
        {
            m_Pointer.Activate();
            m_IsSelected = true;
        }

        public void Unselect()
        {
            m_Pointer.Deactivate();
            m_IsSelected = false;
        }

        public void Decide()
        {
            m_OnDecided.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Utility
{
    public class Timer : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize, PropertyRange(0, 60)] int m_Minutes;
        public int Minutes
        {
            get { return m_Minutes; }
        }

        [OdinSerialize, PropertyRange(0f, 60f)] float m_Seconds;
        public float Seconds
        {
            get { return m_Seconds; }
        }

        [Title("Callback")]
        [OdinSerialize] UnityEvent m_OnTimeElapsed = new UnityEvent();

        private void Update()
        {
            m_Seconds -= Time.deltaTime;

            if (m_Seconds <= 0f)
            {
                if (m_Minutes > 0)
                {
                    m_Minutes--;
                    m_Seconds += 60f;
                }
                else
                {
                    m_OnTimeElapsed.Invoke();
                    m_Seconds = 0f;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}

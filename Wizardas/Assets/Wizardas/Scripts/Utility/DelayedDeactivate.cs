﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Utility
{
    public class DelayedDeactivate : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] float m_Duration = 1f;

        private void Awake()
        {
            StartCoroutine(DelayedDeactivateCoroutine());
        }

        IEnumerator DelayedDeactivateCoroutine()
        {
            yield return new WaitForSeconds(m_Duration);

            gameObject.SetActive(false);
        }
    }
}

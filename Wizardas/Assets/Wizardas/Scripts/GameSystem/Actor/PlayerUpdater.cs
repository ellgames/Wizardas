﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Actor
{
    public class PlayerUpdater : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] IDeadWatch m_IDeadWatch;
        [OdinSerialize, Required] PlayerBehaviour.PlayerBehaviourHandler m_PlayerBehaviourHandler;

        bool m_HasKilled = false;

        private void Update()
        {
            Debug.Assert(m_IDeadWatch != null);

            if (m_IDeadWatch.IsDead())
            {
                if (m_HasKilled == false)
                {
                    m_PlayerBehaviourHandler.Kill();
                    m_HasKilled = true;
                }
            }
            else
            {
                m_HasKilled = false;
            }
        }
    }
}

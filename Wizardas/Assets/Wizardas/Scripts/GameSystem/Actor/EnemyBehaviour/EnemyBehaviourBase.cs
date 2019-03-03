using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Actor.EnemyBehaviour
{
    public abstract class EnemyBehaviourBase : SerializedMonoBehaviour
    {
        [Title("Deactivation")]
        [OdinSerialize] bool m_SelfDeactivate = false;
        [OdinSerialize, EnableIf("m_SelfDeactivate")] float m_Duration;

        float m_ElapsedTime;

        void Initialize()
        {
            m_ElapsedTime = 0f;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnEnable()
        {
            Initialize();
        }

        protected virtual void OnDisable()
        {

        }

        protected virtual void Update()
        {
            if (m_ElapsedTime >= m_Duration)
            {
                if (m_SelfDeactivate)
                {
                    Deactivate();
                }
            }

            m_ElapsedTime += Time.deltaTime;   
        }
    }
}

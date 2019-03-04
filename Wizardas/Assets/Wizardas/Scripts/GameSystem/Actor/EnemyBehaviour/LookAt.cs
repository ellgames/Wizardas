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
    public class LookAt : EnemyBehaviourBase
    {
        [Title("Required")]
        [OdinSerialize, Required] Transform m_User;

        [Title("Settings")]
        [OdinSerialize] Transform m_Target;
        public Transform Target
        {
            set { m_Target = value; }
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (m_Target == null) return;

            m_User.transform.LookAt(m_Target);

            var buffer = transform.eulerAngles;
            buffer.x = 0f;
            buffer.z = 0f;

            m_User.transform.eulerAngles = buffer;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}

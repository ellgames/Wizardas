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
    public class LookAtPlayer : EnemyBehaviourBase
    {
        [Title("Required")]
        [OdinSerialize, Required] Transform m_User;
        [OdinSerialize, Required] Transform m_Player;

        protected override void OnEnable()
        {
            base.OnEnable();

            m_User.transform.LookAt(m_Player);

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

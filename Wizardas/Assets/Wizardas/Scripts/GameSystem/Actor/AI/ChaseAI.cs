using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Actor.AI
{
    public class ChaseAI : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] EnemyBehaviour.EnemyBehaviourHandler m_EnemyBehaviourHandler;

        
    }
}

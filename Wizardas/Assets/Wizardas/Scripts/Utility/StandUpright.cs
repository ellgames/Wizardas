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
    public class StandUpright : SerializedMonoBehaviour
    {
        private void Update()
        {
            var fixedPosition = transform.position;
            fixedPosition.y = 0f;
            transform.position = fixedPosition;
        }
    }
}

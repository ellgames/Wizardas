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
            var fixedRotation = transform.eulerAngles;
            fixedRotation.x = 0f;
            fixedRotation.z = 0f;
            transform.eulerAngles = fixedRotation;
        }
    }
}

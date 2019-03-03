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
            var fixedEulerAngles = transform.eulerAngles;
            fixedEulerAngles.x = 0f;
            fixedEulerAngles.z = 0f;
            transform.eulerAngles = fixedEulerAngles;
        }
    }
}

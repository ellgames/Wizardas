using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Extension
{
    public static class Math
    {
	    public static float HorizontalDistance(Vector3 point1, Vector3 point2)
        {
            point1.y = 0f;
            point2.y = 0f;

            return Vector3.Distance(point1, point2);
        }

        public static Vector3 Flatten(this Vector3 self)
        {
            self.y = 0f;

            return self;
        }
    }
}

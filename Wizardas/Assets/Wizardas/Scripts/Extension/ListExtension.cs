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
    public static class ListExtension
    {
        public static T GetAtRandom<T>(this List<T> self)
        {
            return self[Random.Range(0, self.Count)];
        }
    }
}

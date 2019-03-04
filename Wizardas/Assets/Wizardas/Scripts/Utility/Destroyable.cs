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
    public class Destroyable : SerializedMonoBehaviour
    {
	    public void Destroy()
        {
            Object.Destroy(gameObject);
        }
    }
}

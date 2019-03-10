using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Develop
{
    public class Memo : SerializedMonoBehaviour
    {
	    [OdinSerialize, MultiLineProperty(5)] string m_Text;
    }
}

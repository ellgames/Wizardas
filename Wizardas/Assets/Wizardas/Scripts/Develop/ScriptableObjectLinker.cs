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
    public class ScriptableObjectLinker : SerializedMonoBehaviour
    {
        [OdinSerialize] Profile.GameProfile gameProfile;
        [OdinSerialize] Profile.KillProfile killProfile;
        [OdinSerialize] Profile.PlayerProfile playerProfile;
        [OdinSerialize] Profile.ScoreProfile scoreProfile;
        [OdinSerialize] Profile.SystemProfile systemProfile;
        [OdinSerialize] Profile.ScoreProfile scoreProfile1;
        [OdinSerialize] Profile.ScoreProfile scoreProfile2;
        [OdinSerialize] Profile.ScoreProfile scoreProfile3;
        [OdinSerialize] Profile.ScoreProfile scoreProfile4;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

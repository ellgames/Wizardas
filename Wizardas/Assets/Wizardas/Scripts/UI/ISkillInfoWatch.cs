using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI
{
    public interface ISkillInfoWatch
    {
        Sprite SkillIcon();
        string SkillName();
        string Description();
        float UsingTime();
        float CoolTime();
    }
}

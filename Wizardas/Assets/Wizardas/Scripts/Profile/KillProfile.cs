using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Profile
{
    [CreateAssetMenu(menuName = "Profile/KillProfile", fileName = "KillProfile")]
    public class KillProfile : SerializedScriptableObject, Save.ISavable
    {
        void Save.ISavable.Save()
        {
            ES2.Save(KillCount_WeakGhoul, "KillProfile/KillCount_WeakGhoul");
            ES2.Save(KillCount_WeakUndeadEnt, "KillProfile/KillCount_WeakUndeadEnt");
            ES2.Save(KillCount_Ghoul, "KillProfile/KillCount_Ghoul");
            ES2.Save(KillCount_UndeadEnt, "KillProfile/KillCount_UndeadEnt");
            ES2.Save(KillCount_SuccubusMage, "KillProfile/KillCount_SuccubusMage");
            ES2.Save(KillCount_StrongGhoul, "KillProfile/KillCount_StrongGhoul");
            ES2.Save(KillCount_StrongUndeadEnt, "KillProfile/KillCount_StrongUndeadEnt");
            ES2.Save(KillCount_StrongSuccubusMage, "KillProfile/KillCount_StrongSuccubusMage");
        }

        void Save.ISavable.Load()
        {
            KillCount_WeakGhoul = ES2.Load<uint>("KillProfile/KillCount_WeakGhoul");
            KillCount_WeakUndeadEnt = ES2.Load<uint>("KillProfile/KillCount_WeakUndeadEnt");
            KillCount_Ghoul = ES2.Load<uint>("KillProfile/KillCount_Ghoul");
            KillCount_UndeadEnt = ES2.Load<uint>("KillProfile/KillCount_UndeadEnt");
            KillCount_SuccubusMage = ES2.Load<uint>("KillProfile/KillCount_SuccubusMage");
            KillCount_StrongGhoul = ES2.Load<uint>("KillProfile/KillCount_StrongGhoul");
            KillCount_StrongUndeadEnt = ES2.Load<uint>("KillProfile/KillCount_StrongUndeadEnt");
            KillCount_StrongSuccubusMage = ES2.Load<uint>("KillProfile/KillCount_StrongSuccubusMage");
        }

        [OdinSerialize] public uint KillCount_WeakGhoul { get; set; }
        [OdinSerialize] public uint KillCount_WeakUndeadEnt { get; set; }
        [OdinSerialize] public uint KillCount_Ghoul { get; set; }
        [OdinSerialize] public uint KillCount_UndeadEnt { get; set; }
        [OdinSerialize] public uint KillCount_SuccubusMage { get; set; }
        [OdinSerialize] public uint KillCount_StrongGhoul { get; set; }
        [OdinSerialize] public uint KillCount_StrongUndeadEnt { get; set; }
        [OdinSerialize] public uint KillCount_StrongSuccubusMage { get; set; }

        public void AddKillCount_WeakGhoul() => KillCount_WeakGhoul++;
        public void AddKillCount_WeakUndeadEnt() => KillCount_WeakUndeadEnt++;
        public void AddKillCount_Ghoul() => KillCount_Ghoul++;
        public void AddKillCount_UndeadEnt() => KillCount_UndeadEnt++;
        public void AddKillCount_SuccubusMage() => KillCount_SuccubusMage++;
        public void AddKillCount_StrongGhoul() => KillCount_StrongGhoul++;
        public void AddKillCount_StrongUndeadEnt() => KillCount_StrongUndeadEnt++;
        public void AddKillCount_StrongSuccubusMage() => KillCount_StrongSuccubusMage++;
    }
}
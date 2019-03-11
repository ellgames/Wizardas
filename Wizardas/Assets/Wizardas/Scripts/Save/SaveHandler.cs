using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Save
{
    [CreateAssetMenu(menuName = "Save/SaveHandler", fileName = "SaveHandler")]
    public class SaveHandler : SerializedScriptableObject
    {
        [Title("Settings")]
        [OdinSerialize] List<ISavable> m_ISavables = new List<ISavable>();

        [Button("Save")]
        public void Save()
        {
#if UNITY_EDITOR
            Debug.Log("Saved.");
#endif

            if (m_ISavables == null) return;
            m_ISavables.ForEach(savable => savable.Save());
        }

        [Button("Load")]
        public void Load()
        {
#if UNITY_EDITOR
            Debug.Log("Loaded.");
#endif

            if (m_ISavables == null) return;
            try
            {
                m_ISavables.ForEach(savable => savable.Load());
            }
            catch
            {
#if UNITY_EDITOR
                Debug.Log("Failed to Load.");
#endif
            }
        }

        [Button("Delete")]
        public void Delete()
        {
            ES2.DeleteDefaultFolder();
#if UNITY_EDITOR
            Debug.Log("Save data has been completely deleted.");
#endif
        }
    }
}
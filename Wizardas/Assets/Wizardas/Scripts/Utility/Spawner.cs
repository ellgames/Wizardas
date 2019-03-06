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
    public class Spawner : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] bool m_ActivateOnSpawn = true;
        [OdinSerialize] List<GameObject> m_Spawnables = new List<GameObject>();
        [OdinSerialize] GameObject m_SpawnRoot;
        [OdinSerialize] float m_SpawnInterval = 5f;

        [Title("State")]
        [OdinSerialize] float m_NextSpawnDuration;

        void Spawn()
        {
            Debug.Assert(m_Spawnables != null);
            var index = Random.Range(0, m_Spawnables.Count - 1);
            var spawned = Instantiate(m_Spawnables[index]);
            spawned.transform.parent = m_SpawnRoot.transform;
            spawned.transform.position = transform.position;
            if (m_ActivateOnSpawn) spawned.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (m_NextSpawnDuration <= 0f)
            {
                Spawn();
                m_NextSpawnDuration = m_SpawnInterval;
            }

            m_NextSpawnDuration -= Time.deltaTime;
        }
    }
}

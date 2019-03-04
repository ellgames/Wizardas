using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using EllGames.Wiz.Extension;

namespace EllGames.Wiz.Battle
{
    [RequireComponent(typeof(Collider))]
    public class AttackArea : SerializedMonoBehaviour
    {
        [OdinSerialize] List<GetHitter> m_Contents = new List<GetHitter>();
        public List<GetHitter> Contents
        {
            get { return m_Contents; }
        }

        [OdinSerialize] string m_ContentableTag;

        private void OnTriggerEnter(Collider enterer)
        {
            if (enterer.gameObject.tag != m_ContentableTag) return;

            var getHitter = enterer.gameObject.GetComponent<GetHitter>();

            if (getHitter == null) return;
            if (m_Contents.Contains(getHitter)) return;

            m_Contents.Add(getHitter);
        }

        private void OnTriggerExit(Collider exitter)
        {
            if (exitter.gameObject.tag != m_ContentableTag) return;

            var getHitter = exitter.gameObject.GetComponent<GetHitter>();

            if (getHitter == null) return;
            if (!m_Contents.Contains(getHitter)) return;

            m_Contents.Remove(getHitter);
        }

        private void Update()
        {
            if (m_Contents == null) return;

            // InvalidOperationExceptionを回避するため、二段階に分けて削除
            var removables = new List<GetHitter>();

            m_Contents.ForEach(content =>
            {
                if (content == null) removables.Add(content);
            });

            removables.ForEach(removable =>
            {
                m_Contents.Remove(removable);
            });
        }
    }
}

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
    [RequireComponent(typeof(MeshRenderer))]
    public class InvisibleMeshRendererInGame : SerializedMonoBehaviour
    {
        MeshRenderer m_MeshRenderer;

        // Awakeだとインスペクタ上でチェックボックスが表示されない（非アクティブでも必ず呼ばれる）
        private void Start()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
            m_MeshRenderer.enabled = false;
        }
    }
}

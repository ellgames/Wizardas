using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI.Selection
{
    public class UISelector : SerializedMonoBehaviour
    {
        [Title("Settings")]
        [OdinSerialize] List<Selectable> m_Selectables;

        [Title("SE")]
        [OdinSerialize] bool m_UsingSE = false;
        [OdinSerialize, EnableIf("m_UsingSE")] Audio.SEPlayer m_SEPlayer;
        [OdinSerialize, EnableIf("m_UsingSE")] AudioClip m_SelectSE;
        [OdinSerialize, EnableIf("m_UsingSE")] float m_SelectVolumeScale = 0.8f;
        [OdinSerialize, EnableIf("m_UsingSE")] AudioClip m_DecideSE;
        [OdinSerialize, EnableIf("m_UsingSE")] float m_DecideVolumeScale = 0.8f;
        [OdinSerialize, EnableIf("m_UsingSE")] AudioClip m_CancelSE;
        [OdinSerialize, EnableIf("m_UsingSE")] float m_CancelVolumeScale = 0.8f;

        /// <summary>
        /// 現在選択されているインデックスを返します。
        /// </summary>
        /// <returns>何も選択されていない場合、nullを返します。</returns>
        public int? SelectedIndex()
        {
            for (int index = 0; index < m_Selectables.Count; index++)
            {
                if (m_Selectables[index].IsSelected) return index;
            }

            return null;
        }

        /// <summary>
        /// 何も選択していない状態にします。
        /// </summary>
        public void Unselect()
        {
            m_Selectables.ForEach(option => option.Unselect());
        }

        /// <summary>
        /// すべての選択を解除します。
        /// </summary>
        [Button("Cancel")]
        public void Cancel()
        {
            Unselect();
            if (m_UsingSE) m_SEPlayer.PlayOneShot(m_CancelSE, m_CancelVolumeScale);
        }

        /// <summary>
        /// 指定したインデックスの選択肢を選択します。
        /// </summary>
        /// <param name="index">選択したいインデックスを指定します。</param>
        public void Select(int index)
        {
            Debug.Assert(0 <= index && index < m_Selectables.Count);
            Unselect();
            m_Selectables[index].Select();
            if (m_UsingSE) m_SEPlayer.PlayOneShot(m_SelectSE, m_SelectVolumeScale);
        }

        /// <summary>
        /// 最初の選択肢を選択します。
        /// </summary>
        [Button("Select First")]
        public void SelectFirst()
        {
            Select(0);
        }

        /// <summary>
        /// 最後の選択肢を選択します。
        /// </summary>
        [Button("Select Last")]
        public void SelectLast()
        {
            Select(m_Selectables.Count - 1);
        }

        /// <summary>
        /// 次の選択肢を選択します。
        /// </summary>
        [Button("Select Next")]
        public void SelectNext()
        {
            var selectedIndex = SelectedIndex();

            if (selectedIndex == null)
            {
                SelectFirst();
            }
            else
            {
                var index = (int)selectedIndex;
                if (index + 1 < m_Selectables.Count)
                {
                    Select(index + 1);
                }
                else
                {
                    SelectFirst();
                }
            }
        }

        /// <summary>
        /// 前の選択肢を選択します。
        /// </summary>
        [Button("Select Previous")]
        public void SelectPrevious()
        {
            var selectedIndex = SelectedIndex();

            if (selectedIndex == null)
            {
                SelectLast();
            }
            else
            {
                var index = (int)selectedIndex;
                if (index - 1 >= 0)
                {
                    Select(index - 1);
                }
                else
                {
                    SelectLast();
                }
            }
        }

        /// <summary>
        /// 現在の選択肢で決定します。
        /// </summary>
        [Button("Decide")]
        public void Decide()
        {
            var selectedIndex = SelectedIndex();
            if (selectedIndex == null) return;

            m_Selectables[(int)selectedIndex].Decide();
            if (m_UsingSE) m_SEPlayer.PlayOneShot(m_DecideSE, m_DecideVolumeScale);
        }
    }
}

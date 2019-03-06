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
        [Title("Required")]
        [OdinSerialize, Required] Profile.HitProfile m_HitProfile;
        [OdinSerialize, Required] Profile.SystemProfile m_SystemProfile;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_LF_IM;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_LF_MA;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_FF_IM;
        [OdinSerialize, Required] Profile.ScoreProfile m_HighScoreProfile_FF_MA;

        [Title("Path")]
        [OdinSerialize] string m_DefaultSaveDirectory = "SaveData/";
        [OdinSerialize] string m_SaveFileName_HitCount = "HitCount";
        [OdinSerialize] string m_SaveFileName_Language = "Language";
        [OdinSerialize] string m_SaveFileName_Highscore_LF_IM = "Highscore/LF/IM";
        [OdinSerialize] string m_SaveFileName_Highscore_LF_MA = "Highscore/LF/MA";
        [OdinSerialize] string m_SaveFileName_Highscore_FF_IM = "Highscore/FF/IM";
        [OdinSerialize] string m_SaveFileName_Highscore_FF_MA = "Highscore/FF/MA";

        [Button("Save")]
        public void Save()
        {
#if UNITY_EDITOR
            Debug.Log("Saved.");
#endif
            ES2.Save(m_HitProfile.HitCount, m_DefaultSaveDirectory + m_SaveFileName_HitCount);
            ES2.Save(m_SystemProfile.Language, m_DefaultSaveDirectory + m_SaveFileName_Language);
            ES2.Save(m_HighScoreProfile_LF_IM.Score, m_DefaultSaveDirectory + m_SaveFileName_Highscore_LF_IM);
            ES2.Save(m_HighScoreProfile_LF_MA.Score, m_DefaultSaveDirectory + m_SaveFileName_Highscore_LF_MA);
            ES2.Save(m_HighScoreProfile_FF_IM.Score, m_DefaultSaveDirectory + m_SaveFileName_Highscore_FF_IM);
            ES2.Save(m_HighScoreProfile_FF_MA.Score, m_DefaultSaveDirectory + m_SaveFileName_Highscore_FF_MA);
        }

        [Button("Load")]
        public void Load()
        {
#if UNITY_EDITOR
            Debug.Log("Loaded.");
#endif
            m_HitProfile.ForcedSetHitCount(ES2.Load<int>(m_DefaultSaveDirectory + m_SaveFileName_HitCount));
            m_SystemProfile.Language = ES2.Load<Meta.LANGUAGE>(m_DefaultSaveDirectory + m_SaveFileName_Language);
            m_HighScoreProfile_LF_IM.Score = ES2.Load<int>(m_DefaultSaveDirectory + m_SaveFileName_Highscore_LF_IM);
            m_HighScoreProfile_LF_MA.Score = ES2.Load<int>(m_DefaultSaveDirectory + m_SaveFileName_Highscore_LF_MA);
            m_HighScoreProfile_FF_IM.Score = ES2.Load<int>(m_DefaultSaveDirectory + m_SaveFileName_Highscore_FF_IM);
            m_HighScoreProfile_FF_MA.Score = ES2.Load<int>(m_DefaultSaveDirectory + m_SaveFileName_Highscore_FF_MA);
        }

        [Button("Delete")]
        public void Delete()
        {
            ES2.DeleteDefaultFolder();
#if UNITY_EDITOR
            Debug.Log("Savedata has been completely deleted.");
#endif
        }
    }
}
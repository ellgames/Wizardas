using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem.Score
{
    public class ScoreManager : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.ScoreProfile m_LatestScoreProfile;
        [OdinSerialize, Required] Profile.GameProfile m_LatestGameProfile;
        [OdinSerialize, Required] Guirao.UltimateTextDamage.UltimateTextDamageManager m_UltimateTextDamageManager;

        [Title("Settings")]
        [OdinSerialize] string m_PreAddScoreText = "+";
        [OdinSerialize] string m_PostAddScoreText = " Score";

        int CalculateScore(IKillPoint iKillPoint)
        {
            float mag;

            switch (m_LatestGameProfile.GameDifficulty)
            {
                default:
                    mag = 1f;
                    break;
                case Meta.GAME_DIFFICULTY.Novice:
                    mag = 0.8f;
                    break;
                case Meta.GAME_DIFFICULTY.Hard:
                    mag = 1f;
                    break;
                case Meta.GAME_DIFFICULTY.Veteran:
                    mag = 1.2f;
                    break;
                case Meta.GAME_DIFFICULTY.Master:
                    mag = 1.5f;
                    break;
                case Meta.GAME_DIFFICULTY.Impossible:
                    mag = 2.0f;
                    break;
            }

            var score = 0f;
            score = iKillPoint.KillPoint();
            score *= mag;

            return (int)score;
        }

	    public void AddScore(IKillPoint iKillPoint, Transform addScoreEffectPoint)
        {
            var score = CalculateScore(iKillPoint);

            m_LatestScoreProfile.AddScore(score);
            m_UltimateTextDamageManager.Add(m_PreAddScoreText + score.ToString() + m_PostAddScoreText, addScoreEffectPoint);
        }

        public void Initialize()
        {
            m_LatestScoreProfile.Score = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.GameSystem
{
    public class GameModeManager : SerializedMonoBehaviour
    {
        [Title("Required")]
        [OdinSerialize, Required] Profile.GameProfile m_LatestGameProfile;
        [OdinSerialize, Required] Actor.Status m_PlayerStatus;

        [Title("Training Mode")]
        [OdinSerialize] int m_PlayerMaxHP_TrainingMode = 1000;

        [Title("Limit Fight Mode")]
        [OdinSerialize] int m_PlayerMaxHP_LimitFightMode = 1000;
        [OdinSerialize] GameObject m_Timer;
        [OdinSerialize] GameObject m_TimeLimitNotification;
        [OdinSerialize] GameObject m_TimeLimitBar;

        [Title("Final Fight Mode")]
        [OdinSerialize] int m_PlayerMaxHP_FinalFightMode = 1;
        [OdinSerialize] Actor.PlayerBehaviour.UseSkillCommandBase m_QuicuCureCommand;

        public void Initialize()
        {
            m_PlayerStatus.無敵状態を解除();
            m_TimeLimitNotification.gameObject.SetActive(false);
            m_Timer.gameObject.SetActive(false);
            m_TimeLimitBar.gameObject.SetActive(false);

            switch (m_LatestGameProfile.GameMode)
            {
                case Meta.GAME_MODE.Training:
                    m_PlayerStatus.SetMaxHP(m_PlayerMaxHP_TrainingMode);
                    break;
                case Meta.GAME_MODE.LimitFight:
                    m_PlayerStatus.SetMaxHP(m_PlayerMaxHP_LimitFightMode);
                    break;
                case Meta.GAME_MODE.FinalFight:
                    m_PlayerStatus.SetMaxHP(m_PlayerMaxHP_FinalFightMode);
                    m_QuicuCureCommand.CoolTimeRemain = m_QuicuCureCommand.SkillInfo.CoolTimeSec;
                    break;
            }

            m_PlayerStatus.FullRecovery();
        }

        private void Awake()
        {
            Initialize();

            switch (m_LatestGameProfile.GameMode)
            {
                case Meta.GAME_MODE.Training:
                    m_PlayerStatus.無敵化();
                    m_PlayerStatus.SetMaxHP(m_PlayerMaxHP_TrainingMode);
                    break;
                case Meta.GAME_MODE.LimitFight:
                    m_PlayerStatus.SetMaxHP(m_PlayerMaxHP_LimitFightMode);
                    m_TimeLimitNotification.gameObject.SetActive(true);
                    m_Timer.gameObject.SetActive(true);
                    m_TimeLimitBar.gameObject.SetActive(true);
                    break;
                case Meta.GAME_MODE.FinalFight:
                    m_PlayerStatus.SetMaxHP(m_PlayerMaxHP_FinalFightMode);
                    m_QuicuCureCommand.CoolTimeRemain = m_QuicuCureCommand.SkillInfo.CoolTimeSec;
                    break;
            }

            m_PlayerStatus.FullRecovery();
        }

        private void Update()
        {
            switch (m_LatestGameProfile.GameMode)
            {
                case Meta.GAME_MODE.Training:
                    break;
                case Meta.GAME_MODE.LimitFight:
                    break;
                case Meta.GAME_MODE.FinalFight:
                    m_QuicuCureCommand.CoolTimeRemain = m_QuicuCureCommand.SkillInfo.CoolTimeSec;
                    break;
            }
        }
    }
}

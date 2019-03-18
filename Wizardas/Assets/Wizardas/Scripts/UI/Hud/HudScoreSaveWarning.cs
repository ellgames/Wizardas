using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.UI.Hud
{
    public class HudScoreSaveWarning : HudComponent
    {
	    [OdinSerialize, Required] Profile.GameProfile LatestGameProfile { get; set; }

        private void Awake()
        {
            switch (LatestGameProfile.GameMode)
            {
                case Meta.GAME_MODE.Training:
                    gameObject.SetActive(false);
                    return;
                case Meta.GAME_MODE.LimitFight:
                    break;
                case Meta.GAME_MODE.FinalFight:
                    break;
            }

            switch (LatestGameProfile.GameDifficulty)
            {
                case Meta.GAME_DIFFICULTY.Novice:
                    gameObject.SetActive(false);
                    break;
                case Meta.GAME_DIFFICULTY.Hard:
                    gameObject.SetActive(false);
                    break;
                case Meta.GAME_DIFFICULTY.Veteran:
                    gameObject.SetActive(false);
                    break;
                case Meta.GAME_DIFFICULTY.Master:
                    gameObject.SetActive(true);
                    break;
                case Meta.GAME_DIFFICULTY.Impossible:
                    gameObject.SetActive(true);
                    break;
            }
        }
    }
}

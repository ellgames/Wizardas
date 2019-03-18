using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Audio
{
    public class Fadeout : SerializedMonoBehaviour
    {
        [OdinSerialize] AudioSource AudioSource { get; set; }
	    [OdinSerialize] float Duration { get; set; }
        [OdinSerialize] float Wait { get; set; }

        private void Start()
        {
            StartCoroutine(Coroutine());
        }

        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(Wait);

            var timeElapsed = 0f;

            while (true)
            {
                timeElapsed += Time.deltaTime;
                AudioSource.volume = 1f - timeElapsed / Duration;

                if (timeElapsed >= Duration)
                {
                    break;
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}

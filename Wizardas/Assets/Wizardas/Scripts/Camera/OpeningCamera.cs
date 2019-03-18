using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames
{
    public class OpeningCamera : SerializedMonoBehaviour
    {
        [OdinSerialize] Transform FirstDestination { get; set; }
        [OdinSerialize] float FirstDuration { get; set; } = 5f;
        [OdinSerialize] Transform SecondRotation { get; set; }
        [OdinSerialize] float SecondDuration { get; set; }
        [OdinSerialize] float Wait { get; set; } = 5f;

        private void Start()
        {
            iTween.MoveTo(gameObject, FirstDestination.position, FirstDuration);
            StartCoroutine(DelayedRun());
        }

        IEnumerator DelayedRun()
        {
            yield return new WaitForSeconds(Wait);
            iTween.RotateTo(gameObject, SecondRotation.eulerAngles, SecondDuration);
        }
    }
}

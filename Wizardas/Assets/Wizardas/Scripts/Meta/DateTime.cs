using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace EllGames.Wiz.Meta
{
    [System.Serializable]
    public struct DateTime
    {
        public int Year;
        public int Month;
        public int Day;
        public int Hour;
        public int Minute;
        public int Second;

        public DateTime(int year, int month, int day, int hour, int minute, int second)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public static DateTime operator +(DateTime x, DateTime y)
        {
            DateTime dateTime;
            dateTime.Year = x.Year + y.Year;
            dateTime.Month = x.Month + y.Month;
            dateTime.Day = x.Day + y.Day;
            dateTime.Hour = x.Hour + y.Hour;
            dateTime.Minute = x.Minute + y.Minute;
            dateTime.Second = x.Second + y.Second;

            return dateTime;
        }

        public static DateTime operator -(DateTime x, DateTime y)
        {
            DateTime dateTime;
            dateTime.Year = x.Year - y.Year;
            dateTime.Month = x.Month - y.Month;
            dateTime.Day = x.Day - y.Day;
            dateTime.Hour = x.Hour - y.Hour;
            dateTime.Minute = x.Minute - y.Minute;
            dateTime.Second = x.Second - y.Second;

            return dateTime;
        }

        public static DateTime Zero() => new DateTime(0, 0, 0, 0, 0, 0);
    }
}

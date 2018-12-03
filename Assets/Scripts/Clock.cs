using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {
    [SerializeField]
    float clockTick = 1f;
    static float minutesPerTick = 15;

    [SerializeField]
    Text days;

    [SerializeField]
    Text clock;

    private void Update()
    {
        float minutes = minutesPerTick * Time.timeSinceLevelLoad / clockTick;
        GameSession.ReportDuration(minutes);
        days.text = string.Format("Day {0}", GameSession.Day);
        clock.text = string.Format("{0}:{1}", GameSession.Hour.ToString("D2"), GameSession.Minute.ToString("D2"));
    }
}

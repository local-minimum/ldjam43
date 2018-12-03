using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    static List<string> obituaries = new List<string>();
    static string activeLevel;

    public static void NewGame(string lvl)
    {
        activeLevel = lvl;
        duration = 0;
        obituaries.Clear();
    }

    public static void AddDeath(string obituary) {
        obituaries.Add(obituary);
    }

    public static IEnumerable<string> Obituaries() {
        foreach (string ob in obituaries) yield return ob;
    }

    public static void LoadLastLevel()
    {
        NewGame(string.IsNullOrEmpty(activeLevel) ? "Level A" : activeLevel);
        SceneManager.LoadScene(activeLevel);
    }


    private static string lvlEndReason = "Unknown Reason!";
    public static void ReportLevelEndReaon(string reason)
    {
        lvlEndReason = reason;
    }
    public static string GameOverReason {
        get
        {
            return lvlEndReason;
        } 
    }

    static float duration;
    public static void ReportDuration(float value)
    {
        duration = value;
    }
    public static int Minute
    {
        get
        {
            return Mathf.RoundToInt(duration % 60);
        }
    }
    public static int Day
    {
        get
        {
            return Mathf.FloorToInt((duration / (60 * 24))) + 1;
        }
    }
    public static int Hour
    {
        get
        {
            return Mathf.FloorToInt(duration / 60 - (Day - 1) * 24);
        }
    }
}

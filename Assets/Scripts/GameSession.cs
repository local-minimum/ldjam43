using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    static List<string> obituaries = new List<string>();

    public static void NewGame()
    {
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
        NewGame();
        SceneManager.LoadScene("Level A");
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

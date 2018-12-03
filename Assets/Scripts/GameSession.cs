using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    static List<string> obituaries = new List<string>();

    public static void NewGame()
    {
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    static List<string> obituaries = new List<string>();

    public static void NewGame()
    {
        obituaries.Clear();
    }

    public static void AddDeath(string obituary) {
        obituaries.Add(obituary);
    }
}

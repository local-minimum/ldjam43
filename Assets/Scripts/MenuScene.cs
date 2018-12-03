using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {

    public void PlayLevelA()
    {
        SceneManager.LoadScene("Level A");
    }
}

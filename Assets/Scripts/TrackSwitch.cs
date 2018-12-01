using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSwitch : MonoBehaviour {

    Rail rail;
    [SerializeField]
    GameObject switchOne;
    [SerializeField]
    GameObject switchTwo;

    private void Start()
    {
        switchOne.SetActive(true);
        switchTwo.SetActive(false);
        rail = GetComponent<Rail>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int mode = rail.Switch();
            switchOne.SetActive(mode == 0);
            switchTwo.SetActive(mode == 1);
        }
    }
}

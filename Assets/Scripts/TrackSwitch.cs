using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSwitch : MonoBehaviour {

    Rail rail;

    private void Start()
    {
        rail = GetComponent<Rail>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) rail.Switch();
    }
}

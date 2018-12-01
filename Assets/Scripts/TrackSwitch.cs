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
        int mode = 0;
        rail = GetComponent<Rail>();
        for (int i=0, l=Random.RandomRange(1, 2); i<l; i++)
        {
            mode = rail.Switch();
        }
        UpdateSwitch(mode);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UpdateSwitch(rail.Switch());
        }
    }

    private void UpdateSwitch(int mode)
    {
        switchOne.SetActive(mode == 0);
        switchTwo.SetActive(mode == 1);
    }
}

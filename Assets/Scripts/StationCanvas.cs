using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationCanvas : MonoBehaviour {

    [SerializeField]
    Text text;

    [SerializeField]
    GameObject panel;

    RailHandler handler;

    private void Awake()
    {
        handler = FindObjectOfType<RailHandler>();
    }

    private void OnEnable()
    {
        handler.OnTransaction += Handler_OnTransaction;
    }

    private void OnDisable()
    {
        handler.OnTransaction -= Handler_OnTransaction;
    }

    private void Handler_OnTransaction(int value, Transform localization)
    {
        if (localization == transform.parent)
        {            
            ShowMe(value);
        }        
    }

    public void ShowMe(int income)
    {
        text.text = string.Format("€ {0}", income);
        GetComponent<Animator>().SetTrigger("Show");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour {

    RailHandler rails;

    [SerializeField]
    Text text;

    [SerializeField]
    int balance = 200;

    private void Awake()
    {
        rails = GetComponent<RailHandler>();
    }

    private void OnEnable()
    {
        rails.OnTransaction += Rails_OnTransaction;
    }

    private void OnDisable()
    {
        rails.OnTransaction -= Rails_OnTransaction;
    }

    private void Start()
    {
        text.text = string.Format("€ {0}", balance);
    }

    private void Rails_OnTransaction(int value, Transform localization)
    { 
        balance += value;
        text.text = string.Format("€ {0}", balance);
    }
}

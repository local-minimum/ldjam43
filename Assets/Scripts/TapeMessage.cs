using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapeMessage : MonoBehaviour {

    TickerTape ticker;
    [SerializeField]
    Text text;

    private void Start()
    {
        ticker = GetComponentInParent<TickerTape>();
        gameObject.SetActive(false);
    }

    public void HideTape()
    {
        gameObject.SetActive(false);
    }

    public void CanShowNext()
    {
        ticker.CanShowNext();
    }

    public void StartTape(string message)
    {
        text.text = message;
        gameObject.SetActive(true);        
    }
}

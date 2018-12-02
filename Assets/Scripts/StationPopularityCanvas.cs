using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationPopularityCanvas : MonoBehaviour {

    RailHandler handler;

    [SerializeField]
    Text text;

    [SerializeField]
    GameObject panel;

    private void Awake()
    {
        handler = FindObjectOfType<RailHandler>();
    }

    private void OnEnable()
    {
        handler.OnPopularityGain += Handler_OnPopularityGain;
    }

    private void OnDisable()
    {
        handler.OnPopularityGain -= Handler_OnPopularityGain;
    }

    private void Handler_OnPopularityGain(int value, Transform localization)
    {
        if (localization == transform.parent)
        {
            if (value > 0) ShowMe(value);
        }
    }

    public void ShowMe(int income)
    {
        text.text = string.Format("+{0}", income);
        GetComponent<Animator>().SetTrigger("Show");
    }
}

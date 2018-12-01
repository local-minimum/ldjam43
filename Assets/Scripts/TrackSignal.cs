using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSignal : MonoBehaviour {
    private bool stopping;
    [SerializeField]
    GameObject notStopping;
    [SerializeField]
    GameObject isStopping;

    private void Start()
    {
        notStopping.SetActive(true);
        isStopping.SetActive(false);
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stopping = !stopping;
            notStopping.SetActive(!stopping);
            isStopping.SetActive(stopping);
        }
    }

    public bool Stopping {
        get {
            return stopping;
        }
    }
}

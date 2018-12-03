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
        stopping = Random.value < 0.5f;
        UpdateStopping();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stopping = !stopping;
            UpdateStopping();
        }
    }

    void UpdateStopping()
    {
        
        notStopping.SetActive(!stopping);
        isStopping.SetActive(stopping);
    }

    public bool Stopping {
        get {
            return stopping;
        }
    }
}

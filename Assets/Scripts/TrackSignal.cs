using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSignal : MonoBehaviour {
    private bool stopping;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) stopping = !stopping;
    }

    public bool Stopping {
        get {
            return stopping;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPath : MonoBehaviour {

    [SerializeField]
    Transform[] checkPoints;
    
    public Transform GetTarget(int idx)
    {
        if (idx < checkPoints.Length) return checkPoints[idx];
        return null;
    }
}

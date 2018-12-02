using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPath : MonoBehaviour {

    List<Transform> checkPoints = new List<Transform>();
    int nCheckpoints;

    private void Awake()
    {
        checkPoints.AddRange(GetComponentsInChildren<Transform>());
        checkPoints.Remove(transform);
        nCheckpoints = checkPoints.Count;
    }
    
    public Transform GetTarget(Vector3 currentPosition)
    {
        int bestDistIdx = -1;
        float bestDist = -1;
        for (int i=0; i<nCheckpoints; i++)
        {
            float curDist = Vector3.Distance(currentPosition, checkPoints[i].position);
            if (bestDist < 0 || curDist < bestDist)
            {
                bestDist = curDist;
                bestDistIdx = i;
            }
        }
        return checkPoints[bestDistIdx];
    }
}

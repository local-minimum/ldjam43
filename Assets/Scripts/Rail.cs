using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RailConnector
{
    A1, A2a,
};

public class Rail : MonoBehaviour {

    [SerializeField]
    Transform exitA1;
    [SerializeField]
    Transform exitA2a;
    /*
    [SerializeField]
    Transform exitA2b;
    [SerializeField]
    Transform exitB1;
    [SerializeField]
    Transform exitB2;
    */
	void Start () {
		
	}
	
	void Update () {
		
	}

    public int X
    {
        get
        {
            return Mathf.RoundToInt(transform.position.x);
        }
    }

    public int Y
    {
        get
        {
            return Mathf.RoundToInt(transform.position.z);
        }
    }

    Transform GetSourceConnector(RailConnector connector)
    {
        if (connector == RailConnector.A1)
        {
            return exitA1;
        }
        else if (connector == RailConnector.A2a)
        {
            return exitA2a;
        }
        throw new System.ArgumentException();
    }

    Transform GetTargetConnector(RailConnector connector)
    {
        if (connector == RailConnector.A1)
        {
            return exitA2a;
        } else if ( connector == RailConnector.A2a)
        {
            return exitA1;
        }
        throw new System.ArgumentException();
    }

    public Vector3 GetPosition(RailConnector sourceConnector, float distance, out float overshoot)
    {
        Transform source = GetSourceConnector(sourceConnector);
        Transform target = GetTargetConnector(sourceConnector);
        float length = Vector3.Distance(target.position, source.position);
        float progress = distance / length;
        overshoot = Mathf.Max(0, length - distance);
        return Vector3.Lerp(source.position, target.position, progress);        
    }

    public RailConnector FindSourceConnector(Vector3 position)
    {
        float proximityThreshold = 0.05f;
        if (Vector3.Distance(position, exitA1.position) < proximityThreshold)
        {
            return RailConnector.A1;
        } else if (Vector3.Distance(position, exitA2a.position) < proximityThreshold)
        {
            return RailConnector.A2a;
        }
        throw new System.ArgumentException();
    }
}

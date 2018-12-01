using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RailConnector
{
    StraightA1, StraightA2, StraightB1, StraightB2,
};

public class Rail : MonoBehaviour {

    [SerializeField]
    Transform straightA1;
    [SerializeField]
    Transform straightA2;
    [SerializeField]
    Transform straightB1;
    [SerializeField]
    Transform straightB2;
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
        if (connector == RailConnector.StraightA1)
        {
            return straightA1;
        }
        else if (connector == RailConnector.StraightA2)
        {
            return straightA2;
        } else if (connector == RailConnector.StraightB1)
        {
            return straightB1;
        } else if (connector == RailConnector.StraightB2)
        {
            return straightB2;
        }

        throw new System.ArgumentException();
    }

    Transform GetTargetConnector(RailConnector connector)
    {
        if (connector == RailConnector.StraightA1)
        {
            return straightA2;
        } else if ( connector == RailConnector.StraightA2)
        {
            return straightA1;
        } else if ( connector == RailConnector.StraightB1)
        {
            return straightB2;
        } else if ( connector == RailConnector.StraightB2)
        {
            return straightB1;
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
        if (Vector3.Distance(position, straightA1.position) < proximityThreshold)
        {
            return RailConnector.StraightA1;
        } else if (Vector3.Distance(position, straightA2.position) < proximityThreshold)
        {
            return RailConnector.StraightA2;
        }
        throw new System.ArgumentException();
    }
}

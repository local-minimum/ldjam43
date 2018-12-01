using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RailPos
{
    public int x;
    public int y;

    public RailPos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1})", x, y);
    }
}

public enum RailTrack
{
    SouthNorth, NorthSouth, WestEast, EastWest,
};

public class Rail : MonoBehaviour {

    [SerializeField]
    Transform south;
    [SerializeField]
    Transform north;
    [SerializeField]
    Transform west;
    [SerializeField]
    Transform east;

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

    Transform GetSourceConnector(RailTrack connector)
    {
        if (connector == RailTrack.SouthNorth)
        {
            return south;
        }
        else if (connector == RailTrack.NorthSouth)
        {
            return north;
        } else if (connector == RailTrack.WestEast)
        {
            return west;
        } else if (connector == RailTrack.EastWest)
        {
            return east;
        }
        throw new System.ArgumentException();
    }

    Transform GetTargetConnector(RailTrack connector)
    {
        if (connector == RailTrack.SouthNorth)
        {
            return north;
        } else if ( connector == RailTrack.NorthSouth)
        {
            return south;
        } else if ( connector == RailTrack.WestEast)
        {
            return east;
        } else if ( connector == RailTrack.EastWest)
        {
            return west;
        }
        throw new System.ArgumentException();
    }

    public Vector3 GetPosition(RailTrack track, float distance, out float overshoot)
    {
        Transform source = GetSourceConnector(track);
        Transform target = GetTargetConnector(track);
        float length = Vector3.Distance(target.position, source.position);
        float progress = distance / length;
        overshoot = Mathf.Max(0, distance - length);
        return Vector3.Lerp(source.position, target.position, progress);        
    }

    public RailTrack FindSourceConnector(Vector3 position)
    {
        float proximityThreshold = 0.05f;
        if (Vector3.Distance(position, south.position) < proximityThreshold)
        {
            return RailTrack.SouthNorth;
        } else if (Vector3.Distance(position, north.position) < proximityThreshold)
        {
            return RailTrack.NorthSouth;
        } else if (Vector3.Distance(position, west.position) < proximityThreshold)
        {
            return RailTrack.WestEast;
        } else if (Vector3.Distance(position, east.position) < proximityThreshold)
        {
            return RailTrack.EastWest;
        }
        throw new System.ArgumentException();
    }

    public RailPos GetNextTilePos(RailTrack track)
    {
        switch (track)
        {
            case RailTrack.EastWest:
                return new RailPos(X - 1, Y);
            case RailTrack.WestEast:
                return new RailPos(X + 1, Y);
            case RailTrack.NorthSouth:
                return new RailPos(X, Y - 1);
            case RailTrack.SouthNorth:
                return new RailPos(X, Y + 1);
            default:
                throw new System.ArgumentException();
        }
    }

    private void Start()
    {
        Debug.Log(string.Format("{0} {1} {2}", name, X, Y));
    }
}

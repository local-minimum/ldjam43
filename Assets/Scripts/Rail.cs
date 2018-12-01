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
    SouthWest, SouthEast, EastSouth, WestSouth,
    NorthWest, NorthEast, WestNorth, EastNorth,
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

    [SerializeField]
    RailTrack[] westTracks;

    [SerializeField]
    RailTrack[] eastTracks;

    [SerializeField]
    RailTrack[] northTracks;

    [SerializeField]
    RailTrack[] southTracks;

    int trackSwitch = 0;

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
        switch (connector)
        {
            case RailTrack.SouthNorth:
            case RailTrack.SouthWest:
            case RailTrack.SouthEast:
                return south;
            case RailTrack.NorthEast:
            case RailTrack.NorthSouth:
            case RailTrack.NorthWest:
                return north;
            case RailTrack.EastNorth:
            case RailTrack.EastSouth:
            case RailTrack.EastWest:
                return east;
            case RailTrack.WestEast:
            case RailTrack.WestNorth:
            case RailTrack.WestSouth:
                return west;
        }
        throw new System.ArgumentException();
    }

    Transform GetTargetConnector(RailTrack connector)
    {
        switch (connector)
        {
            case RailTrack.EastSouth:
            case RailTrack.NorthSouth:
            case RailTrack.WestSouth:
                return south;
            case RailTrack.EastWest:
            case RailTrack.NorthWest:
            case RailTrack.SouthWest:
                return west;
            case RailTrack.NorthEast:
            case RailTrack.SouthEast:
            case RailTrack.WestEast:
                return east;
            case RailTrack.EastNorth:
            case RailTrack.SouthNorth:
            case RailTrack.WestNorth:
                return north;
        }
        throw new System.ArgumentException();
    }

    float GetTrackLength(RailTrack track)
    {
        Transform source = GetSourceConnector(track);
        Transform target = GetTargetConnector(track);
        switch (track)
        {
            case RailTrack.NorthSouth:
            case RailTrack.SouthNorth:
            case RailTrack.WestEast:
            case RailTrack.EastWest:
                return Vector3.Distance(target.position, source.position);
            default:
                return Mathf.PI * 0.5f * Mathf.Abs(source.position.x - target.position.x);
        }
    }
    public Vector3 GetPosition(RailTrack track, float distance, out float overshoot)
    {
        Transform source = GetSourceConnector(track);
        Transform target = GetTargetConnector(track);
        float length = GetTrackLength(track);
        float progress = distance / length;
        overshoot = Mathf.Max(0, distance - length);

        switch (track)
        {
            case RailTrack.NorthSouth:
            case RailTrack.SouthNorth:
            case RailTrack.WestEast:
            case RailTrack.EastWest:
                return Vector3.Lerp(source.position, target.position, progress);
            case RailTrack.SouthEast:
            case RailTrack.NorthWest:
                Vector3 origo = new Vector3(target.position.x, source.position.y, source.position.z);
                return GetTurnPosition(origo, source.position, progress, -1);
            case RailTrack.EastNorth:
            case RailTrack.WestSouth:
                origo = new Vector3(source.position.x, source.position.y, target.position.z);
                return GetTurnPosition(origo, source.position, progress, -1);
            case RailTrack.NorthEast:
            case RailTrack.SouthWest:
                origo = new Vector3(target.position.x, source.position.y, source.position.z);
                return GetTurnPosition(origo, source.position, progress, 1);
            case RailTrack.EastSouth:
            case RailTrack.WestNorth:
                origo = new Vector3(source.position.x, source.position.y, target.position.z);
                return GetTurnPosition(origo, source.position, progress, 1);
            default:
                throw new System.ArgumentException();
        }
    }

    Vector3 GetTurnPosition(Vector3 origo, Vector3 source, float progress, float direction)
    {
        float r = Vector3.Distance(source, origo);
        float angle = direction * Mathf.Min(1, progress) * 0.5f * Mathf.PI + Mathf.Atan2(source.z - origo.z, source.x - origo.x);
        return new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * r + origo;
    }

    public Quaternion GetRotaion(RailTrack track, float distance)
    {
        Transform source = GetSourceConnector(track);
        Transform target = GetTargetConnector(track);
        switch (track)
        {
            case RailTrack.SouthNorth:
            case RailTrack.EastWest:
            case RailTrack.NorthSouth:
            case RailTrack.WestEast:
                return Quaternion.LookRotation((target.position - source.position).normalized, Vector3.up);
            case RailTrack.NorthWest:
                float length = GetTrackLength(track);
                float angle = 180 + 90 * Mathf.Min(1, distance / length);
                return Quaternion.AngleAxis(angle, Vector3.up);
            case RailTrack.NorthEast:
                length = GetTrackLength(track);
                angle = 180 - 90 * Mathf.Min(1, distance / length);
                return Quaternion.AngleAxis(angle, Vector3.up);
            case RailTrack.EastNorth:
                length = GetTrackLength(track);
                angle = 270 + 90 * Mathf.Min(1, distance / length);
                return Quaternion.AngleAxis(angle, Vector3.up);
            case RailTrack.EastSouth:
                length = GetTrackLength(track);
                angle = 270 - 90 * Mathf.Min(1, distance / length);
                return Quaternion.AngleAxis(angle, Vector3.up);
            case RailTrack.SouthEast:
                length = GetTrackLength(track);
                angle = 0 + 90 * Mathf.Min(1, distance / length);
                return Quaternion.AngleAxis(angle, Vector3.up);
            case RailTrack.SouthWest:
                length = GetTrackLength(track);
                angle = 0 - 90 * Mathf.Min(1, distance / length);
                return Quaternion.AngleAxis(angle, Vector3.up);
            case RailTrack.WestSouth:
                length = GetTrackLength(track);
                angle = 90 + 90 * Mathf.Min(1, distance / length);
                return Quaternion.AngleAxis(angle, Vector3.up);
            case RailTrack.WestNorth:
                length = GetTrackLength(track);
                angle = 90 - 90 * Mathf.Min(1, distance / length);
                return Quaternion.AngleAxis(angle, Vector3.up);
            default:
                throw new System.ArgumentException();
        }
    }

    public RailTrack GetActiveTrack(Vector3 position)
    {
        float proximityThreshold = 0.05f;
        if (Vector3.Distance(position, south.position) < proximityThreshold)
        {
            if (southTracks.Length > trackSwitch)
            {
                return southTracks[trackSwitch];
            }
        } else if (Vector3.Distance(position, north.position) < proximityThreshold)
        {
            if (northTracks.Length > trackSwitch) {
                return northTracks[trackSwitch];
            }
        } else if (Vector3.Distance(position, west.position) < proximityThreshold)
        {
            if (westTracks.Length > trackSwitch)
            {
                return westTracks[trackSwitch];
            }
        } else if (Vector3.Distance(position, east.position) < proximityThreshold)
        {
            if (eastTracks.Length > trackSwitch)
            {
                return eastTracks[trackSwitch];
            }
        }
        throw new System.ArgumentException();
    }

    public RailPos GetNextTilePos(RailTrack track)
    {
        switch (track)
        {
            case RailTrack.EastWest:
            case RailTrack.NorthWest:
            case RailTrack.SouthWest:
                return new RailPos(X - 1, Y);
            case RailTrack.WestEast:
            case RailTrack.NorthEast:
            case RailTrack.SouthEast:
                return new RailPos(X + 1, Y);
            case RailTrack.NorthSouth:
            case RailTrack.EastSouth:
            case RailTrack.WestSouth:
                return new RailPos(X, Y - 1);
            case RailTrack.SouthNorth:
            case RailTrack.EastNorth:
            case RailTrack.WestNorth:
                return new RailPos(X, Y + 1);
            default:
                throw new System.ArgumentException();
        }
    }

    public void Switch()
    {
        trackSwitch = (trackSwitch + 1) % 2;
    }
}

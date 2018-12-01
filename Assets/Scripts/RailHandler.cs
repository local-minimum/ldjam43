using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailHandler : MonoBehaviour {

    Rail[] rails;

	void Start () {
        rails = FindObjectsOfType<Rail>();
    }

    public Rail FindRailAtCoordinates(RailPos pos)
    {
        return FindRailAtCoordinates(pos.x, pos.y);
    }

    public Rail FindRailAtCoordinates(int X, int Y)
    {
        for (int i=0;i<rails.Length;++i)
        {
            var rail = rails[i];
            if (rail.X == X && rail.Y == Y)
            {
                return rail;
            }
        }
        return null;
    }
}

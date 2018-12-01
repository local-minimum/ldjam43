using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public Rail FindRailAtCoordinates(long X, long Y)
    {
        var rails = FindObjectsOfType<Rail>();
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

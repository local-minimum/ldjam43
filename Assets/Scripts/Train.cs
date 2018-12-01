using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    RailHandler handler;

    [SerializeField]
    Rail rail;

    [SerializeField]
    RailTrack railConnector = RailTrack.SouthNorth;

    float localDistance = 0;

    [SerializeField]
    float speed = 0.1f;

    private void Start()
    {
        handler = FindObjectOfType<RailHandler>();
    }
    void Update () {
        if (!rail)
        {
            Debug.LogWarning("End of Line");
            return;
        }
        localDistance += Time.deltaTime * speed;
        float overshoot;
        Vector3 position = rail.GetPosition(railConnector, localDistance, out overshoot);
        while (overshoot > 0f)
        {
            RailPos pos = rail.GetNextTilePos(railConnector);
            Debug.Log(pos);
            rail = handler.FindRailAtCoordinates(pos);
            localDistance = overshoot;
            if (!rail) break;
            position = rail.GetPosition(railConnector, localDistance, out overshoot);
        }
        position.y = transform.position.y;
        transform.position = position;
	}
}

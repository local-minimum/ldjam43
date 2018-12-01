using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    RailHandler handler;

    [SerializeField]
    Rail rail;

    [SerializeField]
    RailTrack track = RailTrack.SouthNorth;

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
        Vector3 position = rail.GetPosition(track, localDistance, out overshoot);
        Quaternion rotation = rail.GetRotaion(track, localDistance);
        while (overshoot > 0f)
        {
            RailPos pos = rail.GetNextTilePos(track);
            Debug.Log(pos);
            rail = handler.FindRailAtCoordinates(pos);
            localDistance = overshoot;
            if (!rail) break;
            position = rail.GetPosition(track, localDistance, out overshoot);
            rotation = rail.GetRotaion(track, localDistance);
        }
        position.y = transform.position.y;
        transform.position = position;
        transform.rotation = rotation;
	}
}

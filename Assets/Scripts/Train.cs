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

    bool stopped = false;

    private void Start()
    {
        handler = FindObjectOfType<RailHandler>();
    }

    void Update () {
        if (!rail)
        {
            Debug.LogWarning("End of Line");
            return;
        } else if (stopped)
        {
            stopped = rail.Signal.Stopping;
            if (stopped) return;
        }
        localDistance += Time.deltaTime * speed;
        float overshoot;
        Vector3 position = rail.GetPosition(track, localDistance, out overshoot);
        Quaternion rotation = rail.GetRotaion(track, localDistance);
        while (overshoot > 0f)
        {
            RailPos pos = rail.GetNextTilePos(track);                        
            rail = handler.FindRailAtCoordinates(pos);
            localDistance = overshoot;
            if (!rail) break;
            stopped = rail.Signal && rail.Signal.Stopping;
            track = rail.GetActiveTrack(position);
            position = rail.GetPosition(track, localDistance, out overshoot);
            rotation = rail.GetRotaion(track, localDistance);
        }
        position.y = transform.position.y;
        transform.position = position;
        transform.rotation = rotation;
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    [SerializeField]
    Rail rail;

    [SerializeField]
    RailConnector railConnector = RailConnector.A1;

    float localDistance = 0;

    [SerializeField]
    float speed = 0.1f;

	void Update () {
        localDistance += Time.deltaTime * speed;
        float overshoot;
        Vector3 position = rail.GetPosition(railConnector, localDistance, out overshoot);
        position.y = transform.position.y;
        transform.position = position;
	}
}

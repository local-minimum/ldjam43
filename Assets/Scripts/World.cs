using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    [SerializeField]
    private GameObject worldBoundary;

    private Vector3 min;
    private Vector3 max;

    // Use this for initialization
    void Start () {
        var x = worldBoundary.transform.position.x;
        var y = worldBoundary.transform.position.y;
        var boundaryRenderer = worldBoundary.GetComponent<Renderer>();
        max = boundaryRenderer.bounds.max;
        min = boundaryRenderer.bounds.min;
    }

    public Vector2 GetRandomPosition() {
        return new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.x));
    }

    // Update is called once per frame
    void Update () {
		
	}
}

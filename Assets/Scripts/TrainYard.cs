using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainYard : MonoBehaviour {
    [SerializeField]
    Train prefab;

    [SerializeField]
    Rail yard;

    [SerializeField]
    RailTrack track;

    [SerializeField]
    float[] betweenTrains;

    int trainsBuilt = 0;

    float leaveYardTime = 2f;

	void Start () {
        StartCoroutine(MakeTrains());
	}
	
    IEnumerator<WaitForSeconds> MakeTrains()
    {        
        while (true)
        {
            Train train = Instantiate(prefab);
            train.SetRailAndTrack(yard, track);
            yield return new WaitForSeconds(betweenTrains[Mathf.Min(betweenTrains.Length - 1, trainsBuilt)]);
            train.SetBuilt();
            trainsBuilt += 1;
            yield return new WaitForSeconds(leaveYardTime);
        }

    }
}

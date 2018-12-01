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

    bool building = false;

	void Start () {
        StartCoroutine(MakeTrain());
	}
	
    IEnumerator<WaitForSeconds> MakeTrain()
    {
        building = true;
        Train train = Instantiate(prefab);
        train.SetRailAndTrack(yard, track);
        yield return new WaitForSeconds(3f);
        train.SetBuilt();
        building = false;
    }
}

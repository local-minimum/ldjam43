using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TrainCrash(Train train1, Train train2);
public delegate void Fatality(Train train, Person person);
public delegate void AccountTransaction(int vaule);

public class RailHandler : MonoBehaviour {
    [SerializeField]
    int costForTrainsOnRail = 2;
    [SerializeField]
    float costFrequency = 1;

    public event TrainCrash OnTrainCrash;
    public event Fatality OnFatality;
    public event AccountTransaction OnTransaction;

    Rail[] rails;
    bool hasHadCrash;

    List<Train> trains = new List<Train>();
	void Start () {
        rails = FindObjectsOfType<Rail>();
        StartCoroutine(DoCost());
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

    public void ReportTrainCollision(Train train1, Train train2)
    {
        if (!hasHadCrash)
        {
            hasHadCrash = true;
            if (OnTrainCrash != null) OnTrainCrash(train1, train2);
        }
    }

    public void ReportFatality(Train train, Person person)
    {
        if (OnFatality != null) OnFatality(train, person);
    }

    public void ReportNewTrainOnTrack(Train train)
    {
        trains.Add(train);
    }

    IEnumerator<WaitForSeconds> DoCost()
    {
        while (true)
        {
            if (OnTransaction != null) OnTransaction(trains.Count * costForTrainsOnRail);
            yield return new WaitForSeconds(costFrequency);
        }
    }
}

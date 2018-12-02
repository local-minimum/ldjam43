using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void Fatality(Train train, Person person);
public delegate void AccountTransaction(int value, Transform localization);
public delegate void PopularityGain(int value, Transform localization);

public class RailHandler : MonoBehaviour {
    [SerializeField]
    int costForTrainsOnRail = -2;
    [SerializeField]
    float costFrequency = 1;

    public event Fatality OnFatality;
    public event AccountTransaction OnTransaction;
    public event PopularityGain OnPopularityGain;

    Rail[] rails;
    bool hasHadCrash;

    List<Train> trains = new List<Train>();
	void Start () {
        rails = FindObjectsOfType<Rail>();
        StartCoroutine(DoCost());
        lastKill = Time.timeSinceLevelLoad;
    }

    [SerializeField]
    float[] timesWithoutDeathToPopularity;

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
        SceneManager.LoadScene("EndingCollision");
    }

    float lastKill;

    public void ReportFatality(Train train, Person person)
    {
        lastKill = Time.timeSinceLevelLoad;
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
            if (OnTransaction != null) OnTransaction(trains.Count * costForTrainsOnRail, null);
            yield return new WaitForSeconds(costFrequency);
        }
    }

    int GetPopularityGain()
    {
        float noKillTime = Time.timeSinceLevelLoad - lastKill;
        for (int i=0; i<timesWithoutDeathToPopularity.Length; i++)
        {
            if (noKillTime < timesWithoutDeathToPopularity[i])
                return i;
        }
        return timesWithoutDeathToPopularity.Length;
    }

    public void ArriveAtStation(int income, Transform station)
    {
        if (OnTransaction != null) OnTransaction(income, station);
        if (OnPopularityGain != null) OnPopularityGain(GetPopularityGain(), station);
    }
}

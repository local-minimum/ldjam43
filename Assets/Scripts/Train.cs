using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour {

    RailHandler handler;   
    Rail rail;    
    RailTrack track = RailTrack.SouthNorth;

    float localDistance = 0;

    [SerializeField]
    float speed = 0.1f;

    [SerializeField]
    int incomeWhenRunning = 2;
    int cash;
    [SerializeField]
    float incomeFrequency = 1;

    [SerializeField]
    float trainElevation = .05f;

    bool stopped = false;
    bool underConstruction = true;

    private void Start()
    {
        handler = FindObjectOfType<RailHandler>();
    }

    public void SetRailAndTrack(Rail rail, RailTrack track)
    {
        this.track = track;
        this.rail = rail;
        localDistance = 0;
        float overshoot;
        Vector3 postion = rail.GetPosition(track, 0, out overshoot);
        postion.y = trainElevation;
        transform.position = postion;
        transform.rotation = rail.GetRotaion(track, 0);
    }

    public void SetBuilt()
    {
        underConstruction = false;
        handler.ReportNewTrainOnTrack(this);
        StartCoroutine(DoIncome());
    }

    bool isIncoming = false;
    IEnumerator<WaitForSeconds> DoIncome()
    {
        if (!isIncoming)
        {
            isIncoming = true;
            while (!stopped)
            {
                isIncoming = true;
                cash += incomeWhenRunning;
                yield return new WaitForSeconds(incomeFrequency);
            }
            isIncoming = false;
        }
    }

    void Update () {
        if (underConstruction) return;
        if (stopped)
        {
            stopped = !rail || rail.Signal.Stopping;
            if (stopped) return;
            StartCoroutine(DoIncome());
        } else if (!rail)
        {
            Debug.LogWarning("End of Line");
            stopped = true;
            return;
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
        position.y = trainElevation;
        transform.position = position;
        transform.rotation = rotation;
	}

    public bool isDangerous
    {
        get
        {
            return !(stopped || underConstruction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDangerous && collision.collider.tag == "People")
        {
            ContactPoint contact = collision.contacts[0];
            Person person = collision.collider.GetComponent<Person>();
            if (person.IsAlive)
            {
                person.Kill(contact.point + Vector3.up * 0.4f, contact.normal * -70);
                handler.ReportFatality(this, person);
            }            
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;            
        }
        else if (collision.collider.tag == "Train")
        {
            handler.ReportTrainCollision(this, collision.collider.GetComponent<Train>());
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Station")
        {
            handler.ArriveAtStation(cash, other.transform);
            cash = 0;
        }
    }
}

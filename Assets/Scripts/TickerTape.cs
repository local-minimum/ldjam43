using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickerTape : MonoBehaviour {
    [SerializeField]
    RailHandler rails;

    [SerializeField]
    TapeMessage tape1;
    [SerializeField]
    TapeMessage tape2;

    TapeMessage nextTape;

    Queue<string> messages = new Queue<string>();

    bool canShowNext = true;

    private void OnEnable()
    {
        rails.OnFatality += Rails_OnFatality;
    }

    private void OnDisable()
    {
        rails.OnFatality -= Rails_OnFatality;
    }


    private void Rails_OnFatality(Train train, Person person)
    {
        messages.Enqueue(person.KillMessage);
    }

    public void ShowTape()
    {
        if (nextTape == null) nextTape = tape1;
        canShowNext = false;
        string msg = messages.Dequeue();
        nextTape.StartTape(msg);
        if (nextTape == tape2)
        {
            nextTape = tape1;
        } else
        {
            nextTape = tape2;
        }
    }

    public void CanShowNext()
    {
        canShowNext = true;
    }

    private void Update()
    {
        if (canShowNext && messages.Count > 0) ShowTape();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour {

    [SerializeField]
    Person[] prefabs;
    List<Person> recycledPeople = new List<Person>();
    Person NextPerson
    {
        get
        {
            int oldies = recycledPeople.Count;
            if (oldies > 0)
            {
                Person oldie = recycledPeople[Random.Range(0, oldies - 1)];
                recycledPeople.Remove(oldie);
                oldie.Recycle();
                return oldie;
            }

            Person noob = Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)]);
            noob.SetKillCallback(HandleCorpse);
            return noob;
        }
    }
    void HandleCorpse(Person deader)
    {
        recycledPeople.Add(deader);
    }

    [SerializeField]
    WalkPath[] Paths;
    [SerializeField]
    int[] pathSequenceChoices;
    int pathIdx = -1;
    WalkPath NextPath
    {
        get
        {
            pathIdx = (pathIdx + 1) % pathSequenceChoices.Length;
            return Paths[pathSequenceChoices[pathIdx]];
        }
    }

    [SerializeField]
    float[] delays;
    int delayIdx = -1;
    float NextDelay
    {
        get
        {
            delayIdx = (delayIdx + 1) % delays.Length;
            return delays[delayIdx];
        }
    }

    void Start () {
        StartCoroutine(Spawner());
	}

    IEnumerator<WaitForSeconds> Spawner()
    {
        while (true)
        {
            Person person = NextPerson;
            person.SetWalkingPath(NextPath);
            yield return new WaitForSeconds(NextDelay);
        }
    }
}

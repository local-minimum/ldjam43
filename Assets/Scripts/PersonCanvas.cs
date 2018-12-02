using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonCanvas : MonoBehaviour {
    [SerializeField]
    Text text;

    [SerializeField]
    int costOfKilling;

    RailHandler handler;
    Person me;
    Quaternion myRotation;
    Vector3 myOffset;

    private void Awake()
    {
        handler = FindObjectOfType<RailHandler>();
        me = GetComponentInParent<Person>();
        myRotation = transform.rotation;
        myOffset = transform.position - transform.parent.position;
    }

    private void OnEnable()
    {
        handler.OnFatality += Handler_OnFatality;
    }

    private void OnDisable()
    {
        handler.OnFatality -= Handler_OnFatality;
    }

    private void Handler_OnFatality(Train train, Person person)
    {        
        if (person == me)
        {
            text.text = string.Format("-{0}", costOfKilling);
            GetComponent<Animator>().SetTrigger("Show");
        }
    }

    private void LateUpdate()
    {
        transform.position = transform.parent.position + myOffset;
        transform.rotation = myRotation;
    }
}

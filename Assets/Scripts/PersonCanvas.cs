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
    Rigidbody meBody;
    Quaternion myRotation;
    Vector3 myOffset = new Vector3(0, 5, -1.8f);

    private void Awake()
    {
        if (handler == null)
        {
            handler = FindObjectOfType<RailHandler>();
            me = GetComponentInParent<Person>();
            meBody = me.GetComponentInChildren<Rigidbody>();
            myRotation = transform.rotation;
        }
    }

    private void OnEnable()
    {
        handler.OnFatality += Handler_OnFatality;
    }

    private void OnDisable()
    {
        handler.OnFatality -= Handler_OnFatality;
    }

    Vector3 showPosition;

    private void Handler_OnFatality(Train train, Person person)
    {        
        if (person == me)
        {
            showPosition = meBody.transform.position + myOffset;            
            text.text = string.Format("-{0}", costOfKilling);
            GetComponent<Animator>().SetTrigger("Show");
        }
    }

    private void LateUpdate()
    {
        transform.position = showPosition;
        transform.rotation = myRotation;
    }
}

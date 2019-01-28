using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ModusEvents
{
    // THIS LISTENS TO THE THE EVENT

    public class ModEventListener : MonoBehaviour
    {
        public GameObject Ceiling;

            //now when we declare the evnt we are listenting to and then when we fire the event, we just fire the event of the right type.
            // and then anything that is trying to listen to the event of that type will be notified.. Like in this class.
        void Start()
        {
            // we just say I want to register a listener, and this is the kind of info I am looking for..
            // so anyone that fires an event with this info, I want to know about it.. **The info is the type of the event**
            // the structure is the type of the event..
            // whenever an event with this type of info gets fired.. the below function will get called..
            EventSystem.Current.RegisterListener<CeilingOffEventInfo>(CeilingOff);
        }

        // this knows for sure that it gets the right event type.
        void CeilingOff(CeilingOffEventInfo ceilingOffEventInfo)
        {
            Debug.Log("Recieved Event On Listener: " + gameObject.name);
            Debug.Log("Event Description: " + ceilingOffEventInfo.EventDescription);

            // do things
            Ceiling.SetActive(false);

        }
    }
}


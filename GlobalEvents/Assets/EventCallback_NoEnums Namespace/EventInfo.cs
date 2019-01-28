using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ModusEvents
{
    public abstract class EventInfo
    {
        // This is be base Event Info to pass through to the FireEvent() function and send along to the EventSystem.
        // all events will have an event description.
        public string EventDescription;
    }

    public class DebugEventInfo : EventInfo
    {
        ////public int VerbosityLevel;
    }

    public class CeilingOffEventInfo : EventInfo
    {
        public GameObject ModParent;

        void Start()
        {

        }
    }

    //this vlass in inherited from the EventInfo
    //unit death info IS an eEventInfo its just adding more specific stuff regarding the specific event type
    // would most likely have one per event type
    public class UnitDeathEventInfo : EventInfo
    {
        public GameObject DeadUnitGO;

        void Start()
        {

        }
    }
}


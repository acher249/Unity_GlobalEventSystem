using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class DeathListener : MonoBehaviour
    {
        // our death listener wants to be told everytime a unit dies..
        // (i.e. our celiingOffListener wants to be told every time ceilingOn is pressed..)

        void Start()
        {
            EventSystem.Current.RegisterListener(EVENT_TYPE.UNIT_DIED, OnUnitDied);
        }

        void OnUnitDied(EventInfo eventInfo)
        {
            // Cast the eventinfo into a unitdeath event info
            UnitDeathEventInfo unitDeathInfo = (UnitDeathEventInfo)eventInfo;

            Debug.Log("Alerted about unit death: " + unitDeathInfo.DeadUnitGO.name);
        }
    }
}


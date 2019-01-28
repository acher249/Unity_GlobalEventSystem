using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    // this class must be on the gameobject that wants to send out events about itself.

    public class Health : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Die();
            }
        }

        void Die()
        {
            // get a new instance of the death info to pass into the event.
            UnitDeathEventInfo udei = new UnitDeathEventInfo();
            udei.EventDescription = "Unit " + gameObject.name + " has died.";
            udei.DeadUnitGO = gameObject;

            EventSystem.Current.FireEvent(
                EVENT_TYPE.UNIT_DIED,
                udei
                );

            Destroy(gameObject);

        }

    }
}



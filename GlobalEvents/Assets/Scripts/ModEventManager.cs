using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModusEvents
{
    // THIS FIRES THE EVENT
    // this fires the event through the eventSystem for listeners on Gameobjects to pick up.

    // this class must be on the gameobject that wants to send out events about itself.
    // similare to health class in other examples

    public class ModEventManager : MonoBehaviour
    {
        //void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.D))
        //    {
        //        Die();
        //    }
        //}

        // void Die()
        public void CeilingOff()
        {
            // get a new instance of the death info to pass into the event.
            //UnitDeathEventInfo udei = new UnitDeathEventInfo();
            //udei.EventDescription = "Unit " + gameObject.name + " has died.";
            //udei.DeadUnitGO = gameObject;

            CeilingOffEventInfo coi = new CeilingOffEventInfo();
            coi.EventDescription = "Button Was Pressed to Turn the Ceiling Off";
            //coi.ModParent = gameObject;

            // udei tells you what kind of event that it is and has all of the data associated.
            EventSystem.Current.FireEvent(
                coi
                );

            //Destroy(gameObject);
        }

    }
}

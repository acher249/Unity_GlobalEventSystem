using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectCallbacks
{
    public class Health : MonoBehaviour
    {
        // this is attached to all spawned Units..
        // if this unit dies other functions can find all of the unitDeathInfo about this unit


        // define a template of signature for a funtion
        public delegate void OnDeathCallbackDelegate(UnitDeathInfo unitDeathInfo);

        // this makes a list of OnDeathCallbacks that we can add or remove things from.
        // we can make this static to make this shared by all instances of the class
        static public event OnDeathCallbackDelegate OnDeathListeners;
        

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                Die();
            }
        }

        void Die()
        {
            // you could do all of the things here
            // we just want to make an event so that other scripts can just listen for the death

            //Let all of the listeners know that we have died
            if (OnDeathListeners != null)
            {
                UnitDeathInfo udi = new UnitDeathInfo();

                //populating the UnitDeathInfo with this gameobject
                udi.DeadUnitGO = gameObject;

                // this will call all functions that are registered in our death listeners
                OnDeathListeners(udi);    

            }

            Destroy(gameObject);
        }

    }
}



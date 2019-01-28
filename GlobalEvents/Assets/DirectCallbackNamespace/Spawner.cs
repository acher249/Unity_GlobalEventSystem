using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectCallbacks
{
    public class Spawner : MonoBehaviour
    {
        public GameObject UnitPrefab;

        // for every unit that gets spawned we have to tell that unit.. hey, I want to listen to you in case you die.
        // that means that we need another set of listeners for the Unit..

        // health may a well been called UnitPrefab
        public delegate void OnUnitSpawnedDelegate(Health health);
        public event OnUnitSpawnedDelegate OnUnitSpawnedListeners;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SpawnUnit();
            }
        }

        void SpawnUnit()
        {
            GameObject go = Instantiate(UnitPrefab);

            //whenever we spawn a unity we say.. 
            if (OnUnitSpawnedListeners != null)
            {
                //  when we spawn a unit, we get the health component of this newly spawned gameobject
                // and then we want to let anyone who wants to listen in, know that this is happening.
                OnUnitSpawnedListeners(go.GetComponent<Health>());
            }
        }

    }
}


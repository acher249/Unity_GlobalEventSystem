using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectCallbacks
{
    public class DeathListener : MonoBehaviour
    {
        void Start()
        {
            // when a unit gets spawned.. please call my OnUnitSpawned() function.
            // we are listening to the event that is on the unit
            // Spawner spawner = GameObject.FindObjectOfType<Spawner>();
            // spawner.OnUnitSpawnedListeners += OnUnitSpawned;

            // Get the whole static class that has the OnDeathListeners
            // So now we have registered ourselves on the class level..
            // so all units.. for everything with a health componenet, we want to be told when they die.
            Health.OnDeathListeners += OnUnitDied;
        }

        //we listen for when a unit gets spawned and then when a unit gets spawned we say hey.. let me know when you die please..
        //void OnUnitSpawned(Health health)
        //{
        //    Debug.Log("OnUnitSpawned notified..");
        //    health.OnDeathListeners += OnUnitDied;
        //}

        void OnUnitDied(UnitDeathInfo unitDeathInfo)
        {
            // Here we know the information about the unit that died.. we can filter etc..
            // the mod events:
            // CeilingOn and CeilingOff
            // ExplodeMod and ImplodeMod
            // DesignOptionOneOn and DesignOptionTwoOn (these would take care of turning off the others)
            // OneToOneScaleOn and OneToOneScaleOff

            Debug.Log("Alerted about unit death: " + unitDeathInfo.DeadUnitGO.name);
        }
    }
}


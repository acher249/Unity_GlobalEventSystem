using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class Spawner : MonoBehaviour
    {
        public GameObject UnitPrefab;

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

        }

    }
}


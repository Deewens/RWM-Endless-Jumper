using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Missiles
{
    public class MissilesManager : MonoBehaviour
    {
        [SerializeField] private float minTimeBeforeSpawn;
        [SerializeField] private float maxTimeBeforeSpawn;
        
        [SerializeField] private GameObject missilePrefab;
        [SerializeField] private Transform missileSpawnPoint;

        private void Start()
        {
            StartCoroutine(SpawnMissiles());
        }

        private IEnumerator SpawnMissiles()
        {
            while (true)
            {
                Instantiate(missilePrefab, missileSpawnPoint);

                float timeBeforeSpawn = Random.Range(minTimeBeforeSpawn, maxTimeBeforeSpawn);
                yield return new WaitForSeconds(timeBeforeSpawn);
            }
        }
    }
}
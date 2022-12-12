using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Missiles
{
    public class MissilesManager : MonoBehaviour
    {
        [SerializeField] private float minTimeBeforeSpawn;
        [SerializeField] private float maxTimeBeforeSpawn;

        [SerializeField] private float minYPosSpawn = -1f;
        [SerializeField] private float maxYPosSpawn = 1f;
        
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
                float spawnHeight = Random.Range(minYPosSpawn, maxYPosSpawn);
                Vector2 spawnPosition = new Vector2(missileSpawnPoint.position.x, spawnHeight);
                
                // Instantiate missile with a random height
                var spawnedMissile = Instantiate(missilePrefab, spawnPosition, Quaternion.identity);
                spawnedMissile.transform.SetParent(missileSpawnPoint);

                float timeBeforeSpawn = Random.Range(minTimeBeforeSpawn, maxTimeBeforeSpawn);
                yield return new WaitForSeconds(timeBeforeSpawn);
            }
        }
    }
}
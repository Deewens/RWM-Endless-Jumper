using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Missiles
{
    public class MissilesManager : MonoBehaviour
    {
        [SerializeField] private float minYPosSpawn = -1f;
        [SerializeField] private float maxYPosSpawn = 1f;
        
        [SerializeField] private GameObject missilePrefab;
        [SerializeField] private Transform missileSpawnPoint;

        
        [SerializeField] private float difficultyChangeRate = 25f;

        [SerializeField] private List<float> timesBeforeSpawn = new();
        private float _timeBeforeSpawn;
        
        private float _nextDifficultyChangeTime;

        private void Start()
        {
            _timeBeforeSpawn = timesBeforeSpawn[0];
            StartCoroutine(SpawnMissiles());
        }
        
        private void Update()
        {
            if (timesBeforeSpawn.Count > 0)
            {
                if (Time.time > _nextDifficultyChangeTime)
                {   
                    _nextDifficultyChangeTime = Time.time + difficultyChangeRate;
                    IncreaseTimeDifficulty();
                }
            }
        }
        
        private void IncreaseTimeDifficulty()
        {
            _timeBeforeSpawn = timesBeforeSpawn[0];
            timesBeforeSpawn.RemoveAt(0);
        }

        private IEnumerator SpawnMissiles()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeBeforeSpawn);

                float spawnHeight = Random.Range(minYPosSpawn, maxYPosSpawn);
                Vector2 spawnPosition = new Vector2(missileSpawnPoint.position.x, spawnHeight);
                
                // Instantiate missile with a random height
                var spawnedMissile = Instantiate(missilePrefab, spawnPosition, Quaternion.identity);
                spawnedMissile.transform.SetParent(missileSpawnPoint);
            }
        }
    }
}
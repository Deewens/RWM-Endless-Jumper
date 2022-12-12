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

        [SerializeField] private GameObject warningSignPrefab;

        [SerializeField] private float difficultyChangeRate = 25f;
        [SerializeField] private List<float> timesBeforeSpawn = new();
        
        
        private float _timeBeforeSpawn;
        private float _nextDifficultyChangeTime;

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;

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
                yield return new WaitForSeconds(_timeBeforeSpawn / 2);

                // Generate random height for missile to spawn
                var spawnHeight = Random.Range(minYPosSpawn, maxYPosSpawn);
                var spawnPosition = new Vector2(missileSpawnPoint.position.x, spawnHeight);

                // Spawn warning sign before missile
                var cameraHorizontalHalfSize = _mainCamera.orthographicSize * Screen.width / Screen.height;
                var warningSizeSpawnPos = new Vector2(cameraHorizontalHalfSize - 0.5f, spawnHeight);
                var warningSignGO = Instantiate(warningSignPrefab, warningSizeSpawnPos, Quaternion.identity);

                yield return new WaitForSeconds(_timeBeforeSpawn / 2);

                // Destroy warning sign just before instantiating missile
                Destroy(warningSignGO);

                // Instantiate missile with a random height
                var spawnedMissile = Instantiate(missilePrefab, spawnPosition, Quaternion.identity);
                spawnedMissile.transform.SetParent(missileSpawnPoint);
            }
        }
    }
}
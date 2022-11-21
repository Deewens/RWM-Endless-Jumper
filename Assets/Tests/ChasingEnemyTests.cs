using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ChasingEnemyTests
{
    private GameObject _gameManager;
    private Transform _player;
    private ChasingEnemy _chasingEnemy;
        
    [OneTimeSetUp]
    public void Setup()
    {
        SceneManager.LoadScene("ChasingEnemyScene");

        _player = GameObject.FindWithTag("Player").transform;
        _chasingEnemy = GameObject.FindWithTag("ChasingEnemy").GetComponent<ChasingEnemy>();

        /*_gameManager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager"));
        
        GameObject playerGO =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player 1"));
        _player = playerGO.GetComponent<PlayerController>();       
        
        GameObject gameGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ChasingEnemy"));
        _chasingEnemy = gameGameObject.GetComponent<ChasingEnemy>();*/
    }

    [TearDown]
    public void Teardown()
    {
        
    }
    
    [UnityTest]
    public IEnumerator ChasingEnemySpawnedOnGameStart()
    {
        var initialEnemyPosition = _chasingEnemy.transform.position;
        var playerPosition = _player.transform.position;

        var offset = _chasingEnemy.OffsetFromPlayerStable;

        Assert.Equals(initialEnemyPosition.x, playerPosition.x - offset);
        
        yield return null;
    }
}

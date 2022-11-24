using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coins;

    public void BeginSpawn()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(.4f);

        SpawnCoin();
        StartCoroutine("Spawn");
    }

    public GameObject SpawnCoin()
    {
        int random = Random.Range(1, 5);
        GameObject coin;
        coin = Instantiate(coins);

        coin.SetActive(true);

        // Spawn asteroid HARD CODED FOR NOW as screen boundaries are volatile at this early stege
        // Will need updating!!!!
        coin.transform.position = new Vector3(8, -3, 0);

        return coin;
    }

    public void ClearAsteroids()
    {

        Destroy(coins);
    }

    public void StopSpawning()
    {
        StopCoroutine("Spawn");
    }
}
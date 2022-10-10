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

        Debug.Log("Hit");
        coin.SetActive(true);
        float xPos = Random.Range(-8.0f, 8.0f);

        // Spawn asteroid just above top of screen at a random point along x-axis
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
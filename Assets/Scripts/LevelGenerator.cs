using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject saw;
    [SerializeField] private GameObject coin;

    float timeToSaw;
    float timeToCoin;
    GameObject lastFloor;

    float minTime = 1;
    float currentTime = 5;

    float lastFloorPos;
    Vector3 prevPos = new Vector3(-9.1f, -3.42f, 0.0f);

    public Transform parentFloor;
    public Transform parentSaw;
    public Transform parentCoin;

    private void Awake()
    {
        SetUpLevel();
    }

    private void Update()
    {
        timeToSaw -= Time.deltaTime;
        timeToCoin -= Time.deltaTime;
        lastFloorPos = lastFloor.transform.position.x + lastFloor.GetComponent<SpriteRenderer>().size.x / 2.0f;

        if (lastFloorPos < Camera.main.orthographicSize * 2)
        {
            RandomFloor();
            lastFloorPos = lastFloor.transform.position.x + lastFloor.GetComponent<SpriteRenderer>().size.x / 2.0f;
        }

        if (timeToSaw <= 0)
        {
            RandomSaw();
        }

        if (timeToCoin <= 0)
        {
            RandomCoin();
        }
    }

    private void SetUpLevel()
    {
        lastFloorPos = -8;

        while (lastFloorPos < Camera.main.orthographicSize * 2)
        {
            RandomFloor();
            lastFloorPos = lastFloor.transform.position.x + lastFloor.GetComponent<SpriteRenderer>().size.x / 2.0f;
        }
    }

    private void RandomFloor()
    {
        int floorCount = UnityEngine.Random.Range(3, 5);
        GameObject flooring = null;

        for (int i = 0; i < floorCount; i++)
        {
            flooring = Instantiate(floor, parentFloor);
            flooring.transform.localPosition = prevPos;
            prevPos = prevPos + new Vector3(floor.GetComponent<SpriteRenderer>().size.x - 0.1f, 0, 0);

        }

        float spaceCount = UnityEngine.Random.Range(0.5f, 1.5f);
        //float logItBitch = ;
        prevPos = prevPos + new Vector3(floor.GetComponent<SpriteRenderer>().size.x, 0, 0);

        lastFloor = flooring;
    }

    private void RandomSaw()
    {
        GameObject sawTemp = null;
        Vector3 coinPos = prevPos;

        sawTemp = Instantiate(saw, parentSaw);
        sawTemp.transform.localPosition = new Vector3(prevPos.x, sawTemp.transform.localPosition.y, 0);
        sawTemp.transform.localPosition += new Vector3(UnityEngine.Random.Range(2.0f, 5.0f), 0, 0);

        timeToSaw = UnityEngine.Random.Range(currentTime, currentTime + minTime);

        if (currentTime > minTime)
        {
            currentTime -= 0.4f;
        }
    }

    private void RandomCoin()
    {
        GameObject coinTemp = null;
        int coinCount = UnityEngine.Random.Range(3, 6);
        Vector3 coinPos = prevPos;

        for (int i = 0; i < coinCount; i++)
        {
            coinTemp = Instantiate(coin, parentCoin);
            coinTemp.transform.localPosition = new Vector3(prevPos.x, coinTemp.transform.localPosition.y, 0);
            coinTemp.transform.localPosition += new Vector3(-2 * i + (4 * coinCount), 0, 0);
        }

        timeToCoin = UnityEngine.Random.Range(2.0f, 5.0f);
    }
}
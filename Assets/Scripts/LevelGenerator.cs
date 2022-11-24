using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    GameObject lastFloor;

    float lastFloorPos;
    Vector3 prevPos = new Vector3(-9.1f, -3.42f, 0.0f);

    public Transform parentFloor;

    private void Awake()
    {
        SetUpLevel();
    }

    private void Update()
    {
        lastFloorPos = lastFloor.transform.position.x+ lastFloor.GetComponent<SpriteRenderer>().size.x / 2.0f;

        if (lastFloorPos < Camera.main.orthographicSize * 2)
        {
            //prevPos = new Vector3(13f, -3.42f, 0.0f);
            RandomFloor();
            lastFloorPos = lastFloor.transform.position.x + lastFloor.GetComponent<SpriteRenderer>().size.x / 2.0f;

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
        int floorCount = UnityEngine.Random.Range(2, 4);
        GameObject flooring = null;

        for (int i = 0; i < floorCount; i++)
        {
            flooring = Instantiate(floor, parentFloor);
            flooring.transform.localPosition = prevPos;
            prevPos = prevPos + new Vector3(floor.GetComponent<SpriteRenderer>().size.x, 0, 0);

        }

        float spaceCount = UnityEngine.Random.Range(0.5f, 1.5f);
        //float logItBitch = ;
        prevPos = prevPos + new Vector3(floor.GetComponent<SpriteRenderer>().size.x, 0, 0);

        lastFloor = flooring;
    }
}

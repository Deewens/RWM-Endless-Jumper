using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    Transform axis;
    // Start is called before the first frame update
    void Start()
    {
        axis = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(axis.position, Vector3.forward, 1);
    }
}

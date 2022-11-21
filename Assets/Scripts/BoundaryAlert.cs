using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryAlert : MonoBehaviour
{
    public GameObject alertText;
    public float textDisableTimer = 5.0f; //Specify time after which text is disabled
    public bool textShown = false;

    // Start is called before the first frame update
    void Start()
    {
        alertText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (alertText.activeSelf == true && (Time.time >= textDisableTimer))
        {
            alertText.SetActive(false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Player"))
         {
            Debug.Log("Collide");
             alertText.SetActive(true);
             textDisableTimer = Time.time + textDisableTimer;
             textShown = true;
         }
        
    }
}

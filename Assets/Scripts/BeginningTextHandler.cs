using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeginningTextHandler : MonoBehaviour
{
    public GameObject instructionsText;
    public float textEnableTimer = 2.0f; //Specify when text is enabled
    public float textDisableTimer = 5.0f; //Specify time after which text is disabled
    public bool textShown = false;
    // Start is called before the first frame update
    void Start()
    {
        textEnableTimer += Time.time;
        instructionsText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textShown == false && Time.time >= textEnableTimer)
        {
            EnableText();
        }
        if (instructionsText.activeSelf == true && (Time.time >= textDisableTimer))
        {
            instructionsText.SetActive(false);
        }
    }

    //Call to enable the text, which also sets the timer
    public void EnableText()
    {
        instructionsText.SetActive(true);
        textShown = true;
        textDisableTimer = Time.time + textDisableTimer;
    }
}


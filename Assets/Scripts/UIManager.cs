using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    private DataManager _dataManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _dataManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToFormRatingForm()
    {
        var deaths = _dataManager.TotalDeaths;
        var timePlayed = _dataManager.LongestTimePlayed;
        var score = _dataManager.HighestScore;
        
        Application.OpenURL(
            "https://docs.google.com/forms/d/e/1FAIpQLSdXQnkAjBpgMeBuCi3tl5i9Q0R8kD7bLpNHEZ07kbxKaflS1A/viewform?usp=pp_url&entry.383456041=" + timePlayed + "&entry.1464354073=" + deaths + "&entry.812956385=" + score);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
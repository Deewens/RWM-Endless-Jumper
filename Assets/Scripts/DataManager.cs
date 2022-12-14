using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{ 
    public static DataManager Instance { get; private set; }

    public int HighestScore => _highestScore;

    public float LongestTimePlayed => _longestTimePlayed;

    public int TotalDeaths => _totalDeaths;

    private int _highestScore = 0;
    private float _longestTimePlayed = 0f;
    private int _totalDeaths = 0;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        {
            _highestScore = 0;
            _longestTimePlayed = 0f;
            _totalDeaths = 0;
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
    }

    public void UpdateHighestScore(int score)
    {
        if (score > HighestScore)
            _highestScore = score;
    }

    public void UpdateLongestTimePlayed(float time)
    {
        if (time > LongestTimePlayed)
            _longestTimePlayed = time;
    }

    public void AddDeath()
    {
        _totalDeaths = TotalDeaths + 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerDamageSystem _playerDamageSystem;
    private DataManager _dataManager;
    
    public TMPro.TextMeshProUGUI  scoreText;
    public TMPro.TextMeshProUGUI replayText;
    public static int score = 0;
    private GameObject[] coins;
    private bool scoreDoubled = false;

    private float _startTime;
    private float _dieTime;

    private void Awake()
    {
        replayText.gameObject.SetActive(false);

    }
    private void Start()
    {
        _playerDamageSystem = GameObject.FindWithTag("Player").GetComponent<PlayerDamageSystem>();
        _startTime = Time.time;
        
        _dataManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
        
        coins = GameObject.FindGameObjectsWithTag("Coin");
        scoreText.text = "score: " + score;
        replayText.gameObject.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = "score: " + score;

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    public void setScore(int t_score)
    {
        score += t_score;

        if (scoreDoubled)
        {
            score += t_score;
        }
    }

    
    public void ResetGame()
    {
        if (Time.timeScale == 0)
        {
            replayText.gameObject.SetActive(true);

            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
            _dieTime = Time.time;

            float storeTime = _dieTime - _startTime;
            _dataManager.AddDeath();
            _dataManager.UpdateHighestScore(score);
            _dataManager.UpdateLongestTimePlayed(storeTime);

            score = 0;

        }
    }

    public void DoubleScore()
    {
        scoreDoubled = !scoreDoubled;
        StartCoroutine(HandleDoubleScore());
    }

    IEnumerator HandleDoubleScore()
    {
        yield return new WaitForSeconds(2);
        scoreDoubled = false;
    }
}

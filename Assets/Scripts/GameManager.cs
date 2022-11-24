using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject level;

    private DataManager _dataManager;
    
    public TMPro.TextMeshProUGUI  scoreText;
    public static int score = 0;
    private GameObject[] coins;
    private bool scoreDoubled = false;

    private float _startTime;
    private float _dieTime;
    
    private void Start()
    {
        _startTime = Time.time;
        
        _dataManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
        
        coins = GameObject.FindGameObjectsWithTag("Coin");
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
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
        SceneManager.LoadScene("MainMenu");
        _dieTime = Time.time;

        float storeTime = _dieTime - _startTime;
        _dataManager.UpdateHighestScore(score);
        _dataManager.UpdateLongestTimePlayed(storeTime);

        score = 0;
        
        /*LevelController levelController = level.GetComponent<LevelController>();
        level.transform.position = levelController.StartPosition;
        foreach (GameObject c in coins)
        {
            c.GetComponent<Coin>().ResetCoins();
        }*/
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

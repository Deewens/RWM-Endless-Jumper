using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject level;
    
    public TMPro.TextMeshProUGUI  scoreText;
    public static int score = 0;
    private GameObject[] coins;
    private bool scoreDoubled = false;


    private void Start()
    {
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
        LevelController levelController = level.GetComponent<LevelController>();
        level.transform.position = levelController.StartPosition;
        foreach (GameObject c in coins)
        {
            c.GetComponent<Coin>().ResetCoins();
        }
        score = 0;
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

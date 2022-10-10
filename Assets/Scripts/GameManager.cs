using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject level;
    
    public TMPro.TextMeshProUGUI  scoreText;
    public static int score = 0;


    private void Start()
    {
        scoreText.text = "Score: " + score;
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public void setScore(int t_score)
    {
        score += t_score;
    }

    
    public void ResetGame()
    {
        LevelController levelController = level.GetComponent<LevelController>();
        level.transform.position = levelController.StartPosition;
        score = 0;
    }
}

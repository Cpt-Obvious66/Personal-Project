using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;

    [SerializeField] int startingLives = 3;
    private int lives;

    private GameplayUIManager gameplayUIManager;


    void Start()
    {
        gameplayUIManager = GameObject.Find("GameplayUI").GetComponent<GameplayUIManager>();

        ResetScore();
        ResetLives();
    }

    public void ResetScore()
    {
        score = 0;
        gameplayUIManager.UpdateScore(score);
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(int points)
    {
        score += points;
        gameplayUIManager.UpdateScore(score);
    }

    public void ResetLives()
    {
        lives = startingLives;
        gameplayUIManager.UpdateLives(lives);
    }

    public int GetLives()
    {
        return lives;
    }

    public void LoseLife()
    {
        lives--;
        if (lives < 0)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            gameplayUIManager.UpdateLives(lives);
        }


    }
}

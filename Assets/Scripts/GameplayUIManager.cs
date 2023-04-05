using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayUIManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI playerNameText;
    private TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        playerNameText = GameObject.Find("Player Name Text").GetComponent<TextMeshProUGUI>();
        livesText = GameObject.Find("Lives Text").GetComponent<TextMeshProUGUI>();

        UpdatePlayerName(GameManager.Instance.playerName);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdatePlayerName(string name)
    {
        playerNameText.text = name;
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
}

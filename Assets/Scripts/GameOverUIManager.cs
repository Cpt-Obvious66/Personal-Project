using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUIManager : MonoBehaviour
{
    private RectTransform myRectTransform;
    private TextMeshProUGUI highScoreText;
    private TextMeshProUGUI currentScoreText;
    private TextMeshProUGUI playerNameText;

    private void Awake()
    {
        myRectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        highScoreText = myRectTransform.Find("High Score Text").gameObject.GetComponent<TextMeshProUGUI>();
        currentScoreText = myRectTransform.Find("Current Score Text").gameObject.GetComponent<TextMeshProUGUI>();
        //playerNameText = myRectTransform.Find("Player Name Text").gameObject.GetComponent<TextMeshProUGUI>();

        GameManager.Instance.SetOnMenuScreen(true);

        highScoreText.text = GameManager.Instance.GetHighScoreString();
        currentScoreText.text = GameManager.Instance.GetPlayerName() + " - " + GameManager.Instance.GetCurrentScore();
        //playerNameText.text = GameManager.Instance.GetPlayerName();
    }

    public void RestartGame()
    {
        GameManager.Instance.LoadFirstLevel();
    }

    public void MainMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }
}

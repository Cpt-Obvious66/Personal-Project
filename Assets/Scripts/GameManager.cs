using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    private int highScore;
    private string highScoreString;
    private int currentGameScore;

    private bool onMenuScreen;
    private bool isGameStarted;
    private bool isGameRunning;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        isGameStarted = false;

        LoadPlayerData();
    }

    private void Update()
    {
        if (!isGameStarted && !onMenuScreen)
        {
            StartGame();
        }
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void StartGame()
    {
        isGameStarted = true;
        isGameRunning = true;

        GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().ResetLives();
        GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>().ResetScore();
    }

    public void SetOnMenuScreen(bool onMenu)
    {
        onMenuScreen = onMenu;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public bool IsGameRunning()
    {
        return isGameRunning;
    }

    public void GameOver()
    {
        SetOnMenuScreen(true);
        isGameStarted = false;
        isGameRunning = false;

        // if a new high score is reached
        if (currentGameScore > highScore)
        {
            highScore = currentGameScore;
            highScoreString = playerName + " - " + highScore;
            SavePlayerData();
        }
        StartCoroutine(LoadGameOverScreen());
    }

    IEnumerator LoadGameOverScreen()
    {
        yield return new WaitForSeconds(3);
        int gameOverScene = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(gameOverScene);
    }

    public void LoadMainMenu()
    {
        SetCurrentGameScore(0);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void LoadFirstLevel()
    {
        SetCurrentGameScore(0);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public string GetHighScoreString()
    {
        return highScoreString;
    }

    public void SetHighScore(int score)
    {
        highScore = score;
    }

    public int GetCurrentScore()
    {
        return currentGameScore;
    }

    public void SetCurrentGameScore(int score)
    {
        currentGameScore = score;
    }

    // Save and load data section

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
        public string highScoreString;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;
        data.highScoreString = highScoreString;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
            highScoreString = data.highScoreString;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName = "Placeholder";
    public int highScore;

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

        LoadPlayerData();
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameRunning = true;
    }

    public bool IsGameRunning()
    {
        return isGameRunning;
    }

    public void GameOver()
    {
        isGameRunning = false;
    }

    // Save and load data section

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;

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
        }
    }
}

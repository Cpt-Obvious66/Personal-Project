using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUIManager : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI playerNameInput;
    [SerializeField] private TMP_InputField playerNameInput;

    private void Start()
    {
        GameManager.Instance.SetOnMenuScreen(true);

        if (GameManager.Instance.GetPlayerName() != "")
        {
            playerNameInput.textComponent.text = GameManager.Instance.GetPlayerName();
            playerNameInput.text = GameManager.Instance.GetPlayerName();
        }
    }

    public void UpdatePlayerName()
    {
        GameManager.Instance.SetPlayerName(playerNameInput.textComponent.text);
    }

    public void LoadGameScene()
    {
        // get and load the next scene in the build order
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    public void Exit()
    {
        GameManager.Instance.SavePlayerData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}

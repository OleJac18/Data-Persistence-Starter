using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField userInputField;

    private void Start()
    {
        SetNameAndScore(GameManager.Instance.highScorePlayerName, GameManager.Instance.highScore);
        userInputField.onEndEdit.AddListener(SetName);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    private void SetNameAndScore(String playerName, int highScore)
    {
        scoreText.text = "Best Score: " + playerName + ": " + highScore;
    }

    public void SetName(String name)
    {
        GameManager.Instance.currentPlayerName = name;
        Debug.Log(name);
    }
}

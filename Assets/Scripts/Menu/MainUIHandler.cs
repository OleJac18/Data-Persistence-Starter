using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    private void Start()
    {
        SetNameAndScore(MainManager.Instance.name, MainManager.Instance.score);
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

    }
}

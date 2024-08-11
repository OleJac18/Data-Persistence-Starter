using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public String playerName;
        public int score;
    }

    public void SaveBestPlayer()
    {
        SaveData data = new SaveData();
        data.playerName = highScorePlayerName;
        data.score = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.playerName;
            highScore = data.score;
        }
    }

    public static GameManager Instance;
    public String currentPlayerName;
    public String highScorePlayerName;
    public int highScore;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestPlayer();
    }
}

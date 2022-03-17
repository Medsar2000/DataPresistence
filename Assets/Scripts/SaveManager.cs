using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public string currentPlayerName;
    public int currentScore;

    public string HighPlayerName;
    public int HighScore;

    private void Awake()
    {
        //singeltone
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
      
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int Score;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.PlayerName = HighPlayerName;
        data.Score = HighScore;

        string jsondata = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsondata);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighPlayerName = data.PlayerName;
            HighScore = data.Score;
        }
    }

}

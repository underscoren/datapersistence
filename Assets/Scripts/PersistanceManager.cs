using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager Instance { get; private set; }
    public string username;

    public string highScoreName;
    public int highScore;

    void Awake() {
        if(Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class ScoreData {
        public int score;
        public string name;
    }

    public void LoadScore() {
        string path = Application.persistentDataPath + "/scores.json";

        if(File.Exists(path)) {
            string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);

            highScore = data.score;
            highScoreName = data.name;
        }
    }

    public void SaveScore(int score) {
        string path = Application.persistentDataPath + "/scores.json";
        ScoreData data = new ScoreData();
        data.name = username;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

}

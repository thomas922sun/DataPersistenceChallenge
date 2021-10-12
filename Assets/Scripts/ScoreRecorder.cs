using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreRecorder : MonoBehaviour
{
    public static ScoreRecorder Instance;

    public int highestScore;
    public string highScorePlayerName;

    public string thisPlayerName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighestScore();
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    [System.Serializable]
    class SaveData
    {
        public int highestScore;
        public string highScorePlayerName;
    }

    public void SaveHighestScore()
    {
        SaveData data = new SaveData(); //notice here it's a new SaveData()
        data.highestScore = highestScore;
        data.highScorePlayerName = highScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestScore = data.highestScore;
            highScorePlayerName = data.highScorePlayerName;
        }
    }
}

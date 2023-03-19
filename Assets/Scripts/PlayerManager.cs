using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager Instance;

    public string PlayerName { get; set; }
    public int Score { get; set; }

    public string PlayerNameHighest { get; set; }
    public int ScoreHighest { get; set; }

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    private class SaveData
    {
        public string playerName;
        public int score;

        public SaveData(string pName, int scoreVal)
        {
            playerName = pName;
            score = scoreVal;
        }
    }

    public void SaveScore()
    {
        SaveData data = new SaveData(PlayerManager.Instance.PlayerNameHighest, PlayerManager.Instance.ScoreHighest);

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/score.json";

        File.WriteAllText(path, json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/score.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerManager.Instance.PlayerNameHighest = data.playerName;
            PlayerManager.Instance.ScoreHighest = data.score;
        }
        else
        {
            PlayerManager.Instance.PlayerNameHighest = "No-Highest-Score-Yet";
            PlayerManager.Instance.ScoreHighest = -1;
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public static SaveData instance;
    // Start is called before the first frame update
    public void Save(MySharedData data)
    {
        Debug.Log(Application.persistentDataPath);
       string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", jsonData);
    }
    public MySharedData Load()
    {
        try
        {
            string jsonData = File.ReadAllText(Application.persistentDataPath + "/SaveData.json");
            MySharedData data = JsonUtility.FromJson<MySharedData>(jsonData);
            return data;
        } catch(FileNotFoundException exception)
        {
            Debug.Log("Creating New File: " + exception.Message);
            return null;
        }
    }

}

[System.Serializable]
public class MySharedData
{
    public List<SavedGame> savedGames = new() { new SavedGame()};
    public int savedGamesCounter = 0;
}

[System.Serializable]
public class SavedGame
{
    public int id = 0;
    public string name = "default name";
    public List<MissionLog> missionLogs = new();
    public int memoryEssence = 0;
}

[System.Serializable]
public class MissionLog
{
    public int highestLevel = 1;
    public long finalScore = 0;
    public int enemiesKilled = 0;
    public int enemyBossesKilled = 0 ;
    public bool missionSucceeded = false;
    public int highestMultiplier = 1;
}

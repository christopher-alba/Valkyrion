using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;
    public bool spawnMinibosses;
    

    public int currentMaxEnemyCount = 5;
    public int hardCapMaxEnemyCount = 20;
    public int currentEnemiesAlive = 0;
    public bool gameHasStarted = false;
   
    /*FOR LOCAL SAVED DATA*/
    public int totalLevel = 1;
    public long finalScore = 0;
    public int enemiesKilled = 0;
    public int enemyBossesKilled = 0;
    public bool missionSucceeded = false;

    public int memoryEssenceEarned = 0;
    public List<MissionLog> missionLogs = new();
    public string savedGameName = "default name";

    public int savedGameIDSelected = int.MaxValue;
    public bool isSavedGameSelected = false;

    public int savedGameID = 0;
    public List<SavedGame> savedGames = new();
    public string newSavedGameName = "name not registered";

    public static GameManager instance;

    private Transform player;

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
    private void Start()
    {
        LoadAllLocalData();
    }
    public void LoadAllLocalData()
    {
        MySharedData data = SaveData.instance.Load();
        if (data == null)
        {
            SaveData.instance.Save(new MySharedData());
        }
        else
        {
            savedGames = data.savedGames;
        }
    }

    public void LoadSavedGameData()
    {
        LoadAllLocalData();
        int savedGameIndex = savedGames.FindIndex(savedGame => savedGame.id == savedGameID);
        memoryEssenceEarned = savedGames[savedGameIndex].memoryEssence;
        missionLogs = savedGames[savedGameIndex].missionLogs;
        savedGameName = savedGames[savedGameIndex].name;
    }

    public void ResetFinalStats()
    {
        
        currentMaxEnemyCount = 5;
        currentLevel = 1;
        ScoreManager.instance.resetPlayerScore();
        ScoreManager.instance.resetPlayerScoreMultiplier();

        /*FOR JSON DATA STORAGE*/
        totalLevel = 1;
        finalScore = 0;
        enemiesKilled = 0;
        enemyBossesKilled = 0;
        ScoreManager.instance.highestMultiplier = 1;
        missionSucceeded = false;
        memoryEssenceEarned = 0;
    }
    public void StartGame()
    {
        ResetFinalStats();
        gameHasStarted = true;
        player = FindObjectOfType<shipController>()?.transform;
        ScoreManager.instance.resetPlayerScore();
        ScoreManager.instance.resetPlayerScoreMultiplier();
        LevelManager.instance.SpawnEnemies();
    }
    void IncrementLevels()
    {
        if (spawnMinibosses)
        {
            spawnMinibosses = false;
        } else
        {
            spawnMinibosses = true;
        }
        if (currentLevel == 5)
        {
            currentLevel = 1;
        }
        else
        {
            currentLevel++;
        }
        totalLevel++;
        if (currentMaxEnemyCount < hardCapMaxEnemyCount)
        {
            currentMaxEnemyCount++;
        }

        LevelManager.instance.SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            if (currentEnemiesAlive <= 0 && gameHasStarted)
            {
                currentEnemiesAlive = 1;
                Invoke(nameof(IncrementLevels), 2f);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                Settings.instance.resume();
            } else
            {
                Settings.instance.pause();
            }
        }
    }
    public int calculateMemoryEssence()
    {
        return Mathf.FloorToInt(finalScore / Mathf.Pow(10, 6));
    }

    public void AddSavedGame()
    {
        MySharedData sharedData = SaveData.instance.Load();
        SavedGame savedGame = new();

        savedGame.id = sharedData.savedGamesCounter;
        sharedData.savedGamesCounter++;
        savedGameID = savedGame.id;
        savedGame.name = newSavedGameName;
        savedGameName = newSavedGameName;
       
        sharedData.savedGames.Add(savedGame);
        savedGames.Add(savedGame);
        SaveData.instance.Save(sharedData);
    }

    public void LoadSavedGame(int savedGameIDArg)
    {
        MySharedData sharedData = SaveData.instance.Load();
        savedGameID = savedGameIDArg;
        SavedGame savedGame = sharedData.savedGames.Find(savedGameArg => savedGameArg.id == savedGameID);
        memoryEssenceEarned = savedGame.memoryEssence;
        missionLogs = savedGame.missionLogs;
        savedGameName = savedGame.name;
    }

    public void DeleteSavedGame(int savedGameIDArg)
    {
        MySharedData sharedData = SaveData.instance.Load();
        sharedData.savedGames = sharedData.savedGames.Where(savedGame => savedGame.id != savedGameIDArg).ToList();
        SaveData.instance.Save(sharedData);
        savedGames = sharedData.savedGames;
    }

    public void SaveGameAttemptData()
    {
        MissionLog data = new MissionLog();
        data.highestLevel = totalLevel;
        data.finalScore = finalScore;
        data.enemiesKilled = enemiesKilled;
        data.enemyBossesKilled = enemyBossesKilled;
        data.missionSucceeded = missionSucceeded;
        data.highestMultiplier = ScoreManager.instance.highestMultiplier;

        MySharedData sharedData = SaveData.instance.Load();
        int savedGameIndex = savedGames.FindIndex(savedGame => savedGame.id == savedGameID);
        sharedData.savedGames[savedGameIndex].missionLogs.Add(data);
        sharedData.savedGames[savedGameIndex].memoryEssence += calculateMemoryEssence();
        SaveData.instance.Save(sharedData);
    }
    public void backToMainMenu()
    {
        
        ResetFinalStats();
        LevelChanger.instance.FadeToLevel(0);
        AudioManager.instance.MainMenuMusic();
    }
    public void backToAirbase()
    {
        ResetFinalStats();
        LevelChanger.instance.FadeToLevel(1);
        AudioManager.instance.MainMenuMusic();
    }

}

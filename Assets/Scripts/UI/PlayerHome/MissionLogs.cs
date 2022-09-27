using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionLogs : MonoBehaviour
{
    public GameObject missionLogTemplate;
    public Transform missionLogsContainer;
    private TMP_Text attemptNumber;
    private TMP_Text status;
    private TMP_Text points;
    private TMP_Text level;
    private TMP_Text enemiesKilled;
    private TMP_Text bossesKilled;
    private TMP_Text scoreMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.LoadSavedGameData();
        attemptNumber = missionLogTemplate.transform.GetChild(0).GetComponent<TMP_Text>();
        status = missionLogTemplate.transform.GetChild(1).GetComponent<TMP_Text>();
        points = missionLogTemplate.transform.GetChild(2).GetComponent<TMP_Text>();
        level = missionLogTemplate.transform.GetChild(3).GetComponent<TMP_Text>();
        enemiesKilled = missionLogTemplate.transform.GetChild(4).GetComponent<TMP_Text>();
        bossesKilled = missionLogTemplate.transform.GetChild(5).GetComponent<TMP_Text>();
        scoreMultiplier = missionLogTemplate.transform.GetChild(6).GetComponent<TMP_Text>();
        Debug.Log(GameManager.instance.missionLogs.Count);
        for(int i = GameManager.instance.missionLogs.Count; i > 0; i--)
        {
            MissionLog mission = GameManager.instance.missionLogs[i - 1];
            attemptNumber.text = "ATTEMPT #" + i;
            status.text = "STATUS: " + (mission.missionSucceeded ? "SUCCESS" : "FAILED");
            points.text = "POINTS EARNED: " + mission.finalScore;
            level.text = "HIGHEST LEVEL: " + mission.highestLevel;
            enemiesKilled.text = "ENEMIES KILLED: " + mission.enemiesKilled;
            bossesKilled.text = "BOSSES KILLED: " + mission.enemyBossesKilled;
            scoreMultiplier.text = "HIGHEST MULTIPLIER: " + mission.highestMultiplier;

            Instantiate(missionLogTemplate, missionLogsContainer);
        }
    }
}

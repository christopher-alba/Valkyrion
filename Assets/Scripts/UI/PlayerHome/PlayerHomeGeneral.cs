using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHomeGeneral : MonoBehaviour
{
    public TMP_Text title;
    private void Start()
    {
        GameManager.instance.LoadSavedGameData();
        UpdateTitleText();
    }
    public void SlayValkyrion()
    {
        LevelChanger.instance.FadeToLevel(2);
        GameManager.instance.currentLevel = 1;
        GameManager.instance.totalLevel = 1;
        GameManager.instance.currentEnemiesAlive = 0;
        GameManager.instance.finalScore = 0;
    }
    public void ReturnToMainMenu()
    {
        LevelChanger.instance.FadeToLevel(0);
    }
    public void UpdateTitleText()
    {
        title.text = "The Airbase - Planet Earth21B - Year 2200 - Saved Game: " + GameManager.instance.savedGameName;
    }
}

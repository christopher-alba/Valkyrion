using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text playerScoreUI;
    public TMP_Text playerScoreMultiplierUI;
    public static ScoreManager instance;
    public int playerScoreMultiplier = 1;
    public long playerScore = 0;
    public int highestMultiplier = 1;
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
    private void Update()
    {
        if(playerScoreUI == null && SceneManager.GetActiveScene().buildIndex > 1)
        {
            playerScoreUI = GameObject.Find("PlayerScoreValue")?.GetComponent<TMP_Text>();
            playerScoreUI.text = playerScore.ToString();
        }
        if(playerScoreMultiplierUI == null && SceneManager.GetActiveScene().buildIndex > 1)
        {
            playerScoreMultiplierUI = GameObject.Find("PlayerScoreMultiplier")?.GetComponent<TMP_Text>();
            playerScoreMultiplierUI.text = "x" + playerScoreMultiplier.ToString();
        }
    }
    public void addToPlayerScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        Debug.Log(playerScore);
        playerScoreUI.text = playerScore.ToString();
        GameManager.instance.finalScore += scoreToAdd;
    }
    public void setPlayerScore()
    {
        playerScoreUI.text = playerScore.ToString();
    }
    public void resetPlayerScore()
    {
        Debug.Log("Resetting score from:" + playerScore);
        playerScore = 0;
        if(playerScoreUI != null)
        {
            playerScoreUI.text = playerScore.ToString();
        }
        
    }
    public void  addToPlayerScoreMultiplier(int multiplierToAdd)
    {
        playerScoreMultiplier += multiplierToAdd;
        Debug.Log(playerScoreMultiplier);
        playerScoreMultiplierUI.text = "x" +playerScoreMultiplier.ToString();
    }
    public void resetPlayerScoreMultiplier()
    {
        playerScoreMultiplier = 1;
        if(playerScoreMultiplierUI != null)
        {
            playerScoreMultiplierUI.text = "x" + playerScoreMultiplier.ToString();
        }
        
    }
    public void decrementPlayerScoreMultiplier()
    {
        if(playerScoreMultiplier >= 2)
        {
            playerScoreMultiplier--;
            playerScoreMultiplierUI.text = "x" + playerScoreMultiplier.ToString();

        }
    }
}

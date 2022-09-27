using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        instance = this;    
    }

    public void addToPlayerScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        Debug.Log(playerScore);
        playerScoreUI.text = playerScore.ToString();
        GameManager.instance.finalScore += scoreToAdd;
    }
    public void resetPlayerScore()
    {
        Debug.Log("Resetting score from:" + playerScore);
        playerScore = 0;
        playerScoreUI.text = playerScore.ToString();
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
        playerScoreMultiplierUI.text = "x" + playerScoreMultiplier.ToString();
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

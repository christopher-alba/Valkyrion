using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen instance;
    public TMP_Text finalScore;
    public TMP_Text memoryEssence;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void showGameOver()
    {
        Debug.Log("SHOWING GAME OVER");
        gameObject.SetActive(true);
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
    }
    public void hideGameOver()
    {
        gameObject.SetActive(false);
    }
    public void setFinalScore()
    {
        Debug.Log("SETTING FINAL SCORE 1");
        finalScore.text = "Final Score: " + GameManager.instance.finalScore.ToString();
    }
    public void setMemoryEssence()
    {
        memoryEssence.text = "Memory Essence +" + GameManager.instance.calculateMemoryEssence();
    }
}

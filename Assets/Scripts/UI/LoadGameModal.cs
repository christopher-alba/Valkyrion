using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameModal : MonoBehaviour
{
    public Transform scrollingContent;
    public GameObject savedGameTemplate;
    public GameObject deleteButton;
    private TMP_Text id;
    private TMP_Text savedName;
    private TMP_Text memoryEssence;
    
    // Start is called before the first frame update
    void Start()
    {
        deleteButton = GameObject.Find("ConfirmDelete");
        gameObject.SetActive(false);
        id = savedGameTemplate.transform.GetChild(0).GetComponent<TMP_Text>();
        savedName = savedGameTemplate.transform.GetChild(1).GetComponent<TMP_Text>();
        memoryEssence = savedGameTemplate.transform.GetChild(2).GetComponent<TMP_Text>();
        DisplaySavedData();
    }
    private void Update()
    {
        if(GameManager.instance.isSavedGameSelected)
        {
            deleteButton.SetActive(true);
        } else
        {
            deleteButton.SetActive(false);
        }
    }
    public void ShowLoadGameModal()
    {
        Debug.Log("showing modal");
        gameObject.SetActive(true);
        ReloadSavedGames();
    }
    public void HideLoadGameModal()
    {
        Debug.Log("hiding");
        gameObject.SetActive(false);
    }

    public void ReloadSavedGames()
    {
        ClearDisplaySavedData();
        DisplaySavedData();
    }
    public void ClearDisplaySavedData()
    {
        Debug.Log(scrollingContent.transform.childCount);
        for (int i = scrollingContent.transform.childCount - 1; i >= 0; i--)
        {
            Debug.Log("Destroying object:" + i);
            Destroy(scrollingContent.transform.GetChild(i).gameObject);
        }

    }
    public void DisplaySavedData()
    {
        GameManager.instance.LoadAllLocalData();

        Debug.Log(GameManager.instance.savedGames.Count);
        GameManager.instance.savedGames.ForEach(savedGame =>
        {
            Debug.Log(savedGame.id);
            id.text = "ID: "+ savedGame.id.ToString();
            savedName.text = savedGame.name;
            memoryEssence.text = "Memory Essence: " + savedGame.memoryEssence.ToString();
            Instantiate(savedGameTemplate, scrollingContent);
        });
    }
    public void LoadSavedGame(GameObject savedGame)
    {
        int savedGameID = int.Parse(savedGame.transform.Find("savedGameID").GetComponent<TMP_Text>().text.Split(": ")[1]);
        GameManager.instance.LoadSavedGame(savedGameID);
        LevelChanger.instance.FadeToLevel(1);
    }

    public void SelectSavedGame(GameObject savedGame)
    {
        if(int.Parse(savedGame.transform.Find("savedGameID").GetComponent<TMP_Text>().text.Split(": ")[1]) == GameManager.instance.savedGameIDSelected)
        {
            DeselectSavedGame();
            
        } else
        {
            GameManager.instance.isSavedGameSelected = true;
            GameManager.instance.savedGameIDSelected = int.Parse(savedGame.transform.Find("savedGameID").GetComponent<TMP_Text>().text.Split(": ")[1]);
            Debug.Log("SAVEDGAME SELECTED: " + GameManager.instance.savedGameIDSelected);
        
        }
    }
    public void DeselectSavedGame()
    {
        GameManager.instance.savedGameIDSelected = int.MaxValue;
        GameManager.instance.isSavedGameSelected = false;
    }
    public void DeleteSavedGameFinal()
    {
        Debug.Log("DELETING SAVED GAME FINAL: " + GameManager.instance.savedGameIDSelected);
        GameManager.instance.DeleteSavedGame(GameManager.instance.savedGameIDSelected);
        ReloadSavedGames();
        deleteButton.SetActive(false);

    }
    
}

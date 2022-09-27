using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewSavedGameModal : MonoBehaviour
{
    public TMP_InputField inputValue;
    public static NewSavedGameModal instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void ShowNewSavedGameModal()
    {
        gameObject.SetActive(true);
    }
    public void HideSavedGameModal()
    {
        gameObject.SetActive(false);
    }
    public void updateSavedGameName()
    {
        GameManager.instance.newSavedGameName = inputValue.text;
    }
    public void addSavedGame()
    {
        GameManager.instance.AddSavedGame();
        LevelChanger.instance.FadeToLevel(1);
    }
}

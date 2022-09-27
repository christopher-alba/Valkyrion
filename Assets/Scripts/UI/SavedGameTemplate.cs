using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavedGameTemplate : MonoBehaviour
{
    private Color startingColor;
    private void Start()
    {
        startingColor = transform.GetComponent<Image>().color;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.savedGameIDSelected == int.Parse(transform.Find("savedGameID").GetComponent<TMP_Text>().text.Split(": ")[1]))
        {
            transform.GetComponent<Image>().color = Color.black;
            transform.Find("SelectButton").GetChild(0).GetComponent<TMP_Text>().text = "SELECTED";
        } else
        {
            transform.GetComponent<Image>().color = startingColor;
            transform.Find("SelectButton").GetChild(0).GetComponent<TMP_Text>().text = "SELECT";
        }
    }
}

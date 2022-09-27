using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings instance;
    private void Awake()
    {
        instance = this;    
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void pause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    public void resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}

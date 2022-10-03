using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;
    public static PlayerHealthBar instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;   
    }
    private void Start()
    {
        SetMaxHealth(PlayerLifeController.instance.maxHealth);
        SetHealth(PlayerLifeController.instance.health);
    }
    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        Debug.Log(slider.value);
    }
}

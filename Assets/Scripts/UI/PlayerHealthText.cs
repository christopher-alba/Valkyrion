using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerHealthText : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public static PlayerHealthText instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public void SetHealth(float health)
    {
        healthText.text = health.ToString("n2");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider collision)
    {
        PlayerLifeController playerLifeController = collision.GetComponent<PlayerLifeController>();
        if (playerLifeController != null)
        {
            playerLifeController.maxHealth += 10;
            playerLifeController.health = playerLifeController.maxHealth;
            playerLifeController.SetHealth();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No life controller found");
        }
    }
}

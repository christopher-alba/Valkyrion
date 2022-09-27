using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeController : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    public GameObject explosion;
    private void Start()
    {
        PlayerHealthBar.instance.SetMaxHealth(health);
        PlayerHealthText.instance.SetHealth(health);
    }
    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            PlayerHealthBar.instance.SetHealth(health);
            PlayerHealthText.instance.SetHealth(health);
            Debug.Log(health);
            if (health <= 0)
            {
                Debug.Log("Destroy");
                Instantiate(explosion, transform.position, Quaternion.Euler(90, 0, 0));
                GameOverScreen.instance.showGameOver();
                GameOverScreen.instance.setFinalScore();
                GameOverScreen.instance.setMemoryEssence();
                GameManager.instance.gameHasStarted = false;
                GameManager.instance.SaveGameAttemptData();
                Destroy(gameObject);
            }
        }
    }
}

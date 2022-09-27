using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLifeController : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 10;
    public GameObject explosion;
    public GameObject levelUpPowerUp;
    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            Debug.Log(health);
            if (health <= 0) {
                GameManager.instance.enemiesKilled++;
                if (gameObject.tag.Contains("Boss"))
                {
                    GameManager.instance.enemyBossesKilled++;
                    ScoreManager.instance.addToPlayerScore(ScoreManager.instance.playerScoreMultiplier * 10000);
                    ScoreManager.instance.addToPlayerScoreMultiplier(100);
                    AudioManager.instance.LevelMusic();
                } else if (gameObject.tag.Contains("Miniboss")) {
                    ScoreManager.instance.addToPlayerScore(ScoreManager.instance.playerScoreMultiplier * 1000);
                    ScoreManager.instance.addToPlayerScoreMultiplier(10);
                }
                else
                {
                    ScoreManager.instance.addToPlayerScore(ScoreManager.instance.playerScoreMultiplier * 300);
                    ScoreManager.instance.addToPlayerScoreMultiplier(1);
                }

                if(ScoreManager.instance.playerScoreMultiplier > ScoreManager.instance.highestMultiplier)
                {
                    ScoreManager.instance.highestMultiplier = ScoreManager.instance.playerScoreMultiplier; 
                }
               
                Instantiate(explosion, transform.position, Quaternion.Euler(90, 0, 0));
                if(Random.Range(0,100) < 3)
                {
                    Instantiate(levelUpPowerUp, transform.position, Quaternion.Euler(90, 0, 0));
                }
                Destroy(gameObject);
                GameManager.instance.currentEnemiesAlive--;
            }
        }
    }
}

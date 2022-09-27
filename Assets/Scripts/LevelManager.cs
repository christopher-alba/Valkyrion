using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public BoxCollider enemySpawn;
    public GameObject[] enemies;
    public GameObject[] miniBosses;
    public GameObject[] bosses;
    private Transform player;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Debug.Log("TESTINGA");
        enemySpawn = GameObject.Find("EnemySpawn").GetComponent<BoxCollider>();
        player = GameObject.Find("PlayerShip").GetComponent<Transform>();
        Debug.Log(enemySpawn);
        GameManager.instance.StartGame();
        AudioManager.instance.LevelMusic();
    }
    private void spawnRegularEnemies()
    {
        for (int i = 0; i < GameManager.instance.currentMaxEnemyCount; i++)
        {
            Transform transform = enemies[Mathf.RoundToInt(Random.Range(0, enemies.Length))].transform;
            Debug.Log(enemySpawn.bounds.max.x);
            transform.position = new Vector3(Random.Range(enemySpawn.bounds.min.x, enemySpawn.bounds.max.x),
                                             player.position.y,
                                             Random.Range(enemySpawn.bounds.min.z, enemySpawn.bounds.max.z)
                                            );
            Instantiate(
                enemies[Mathf.RoundToInt(Random.Range(0, enemies.Length))],
                transform.position,
                Quaternion.LookRotation(transform.forward, Vector3.forward)
            );
            GameManager.instance.currentEnemiesAlive++;
        }
    }
    private void spawnMiniBossEnemies()
    {
        for (int i = 0; i < Mathf.Round(GameManager.instance.currentMaxEnemyCount/3); i++)
        {
            Transform transform = miniBosses[Mathf.RoundToInt(Random.Range(0, miniBosses.Length))].transform;
            Debug.Log(enemySpawn.bounds.max.x);
            transform.position = new Vector3(Random.Range(enemySpawn.bounds.min.x, enemySpawn.bounds.max.x),
                                             player.position.y,
                                             Random.Range(enemySpawn.bounds.min.z, enemySpawn.bounds.max.z)
                                            );
            Instantiate(
                miniBosses[Mathf.RoundToInt(Random.Range(0, enemies.Length))],
                transform.position,
                Quaternion.LookRotation(transform.forward, Vector3.forward)
            );
            GameManager.instance.currentEnemiesAlive++;
        }
    }

    private void spawnBossEnemy()
    {
        AudioManager.instance.BossMusic();
        Transform transform = bosses[Mathf.RoundToInt(Random.Range(0, bosses.Length))].transform;
        transform.position = new Vector3(Random.Range(enemySpawn.bounds.min.x, enemySpawn.bounds.max.x),
                                         player.transform.position.y,
                                         Random.Range(enemySpawn.bounds.min.z, enemySpawn.bounds.max.z)
                                        );
        GameManager.instance.currentEnemiesAlive = 1;
        Instantiate(
            bosses[Mathf.RoundToInt(Random.Range(0, bosses.Length))],
            transform.position,
            Quaternion.LookRotation(transform.forward, Vector3.forward)
        );
    }
    public void SpawnEnemies()
    {
        GameManager.instance.currentEnemiesAlive = 0;
        if(GameManager.instance.currentLevel == 5)
        {
            spawnBossEnemy();
        }
        else if (GameManager.instance.spawnMinibosses == true)
        {
            spawnMiniBossEnemies();
            spawnRegularEnemies();
        } else
        {
            spawnRegularEnemies();
        }
    }
}

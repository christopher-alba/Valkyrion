using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBoss1Shoot : MonoBehaviour
{
    public GameObject[] bullets;
    public GameObject lazerCharge;
    public Transform player;
    public float fireRateRockets = 5;
    public float fireRateLazer = 10;
    public int rocketBarrageCount = 10;
    public Transform[] enemyFirePoints;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<shipController>()?.transform;
        InvokeRepeating(nameof(fireRockets), fireRateRockets, fireRateRockets);
        InvokeRepeating(nameof(fireLazers), fireRateLazer, fireRateLazer);
    }

    IEnumerator TimeoutForSecondsRockets()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        for (int i = 0; i < rocketBarrageCount; i++)
        {
            Instantiate(bullets[0], enemyFirePoints[0].position, enemyFirePoints[0].rotation);
            Instantiate(bullets[0], enemyFirePoints[1].position, enemyFirePoints[1].rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }

    void fireRockets()
    {
        StartCoroutine(TimeoutForSecondsRockets());
    }
    IEnumerator ChargeAndFireLazers()
    {
        Instantiate(lazerCharge, enemyFirePoints[2].position + new Vector3(0,0,-40), enemyFirePoints[2].rotation);
        Instantiate(lazerCharge, enemyFirePoints[3].position + new Vector3(0, 0, -40), enemyFirePoints[3].rotation);
        yield return new WaitForSeconds(2);
        Instantiate(bullets[1], enemyFirePoints[2].position, enemyFirePoints[2].rotation);
        Instantiate(bullets[1], enemyFirePoints[3].position, enemyFirePoints[3].rotation);
    }
    void fireLazers()
    { 
        StartCoroutine(ChargeAndFireLazers());
    }
    void Update()
    { 
        if (player == null)
        {
            player = FindObjectOfType<shipController>()?.transform;
            if (player == null)
            {
                CancelInvoke(nameof(fireRockets));
                CancelInvoke(nameof(fireLazers));
            }
        }
    }
}

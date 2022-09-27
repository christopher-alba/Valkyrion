using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject[] bullets;
    public Transform player;
    public float fireRate1;
    public float fireRate2;
    public int minigunBarrageCount = 5;
    public Transform[] enemyFirePoints;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<shipController>()?.transform;
        InvokeRepeating(nameof(fire1), fireRate1, fireRate1);
        InvokeRepeating(nameof(fire2), fireRate2, fireRate2);
    }
    IEnumerator TimeoutForSecondsMinigun()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        for (int i = 0; i < minigunBarrageCount; i++)
        {
            Instantiate(bullets[0], enemyFirePoints[2].position, enemyFirePoints[2].rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }
    void fire1()
    {
        StartCoroutine(TimeoutForSecondsMinigun());
    }
    void fire2()
    {
        
         Instantiate(bullets[1], enemyFirePoints[0].position, enemyFirePoints[0].rotation);
         Instantiate(bullets[1], enemyFirePoints[1].position, enemyFirePoints[1].rotation);
    }
    void Update()
    {
        if(player == null)
        {
            CancelInvoke("fire1");
            CancelInvoke("fire2");
        }
        
    }
}

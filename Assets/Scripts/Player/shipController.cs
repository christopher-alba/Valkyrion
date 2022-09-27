using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour
{
    public float speed;
    public static shipController instance;
    public GameObject playerBullet;
    public GameObject playerRocket;
    private float fireRate = 5;
    public int fireLevel = 1;
    public int maxFireLevel = 6;
    public int maxRocketLevel = 9;
    public int rocketLevel = 0;
    private float rocketFireRate = 0.3f;
    private float nextFire;
    private float nextRockets;
    public Transform[] firePoints;

    // Update is called once per frame
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if(fireLevel >= 1)
            {
                Instantiate(playerBullet, firePoints[0].position, firePoints[0].rotation);
                Instantiate(playerBullet, firePoints[1].position, firePoints[1].rotation);
            }
            if(fireLevel >= 2)
            {      
                Instantiate(playerBullet, firePoints[2].position, firePoints[2].rotation);
                Instantiate(playerBullet, firePoints[3].position, firePoints[3].rotation);
            }
            if(fireLevel >= 3)
            {
                int spreadAngle = 5;
                for(int i = 0; i < fireLevel - 2 && i < 4; i++)
                {
                    
                    Instantiate(playerBullet, firePoints[2].position, firePoints[2].rotation * Quaternion.Inverse(Quaternion.Euler(0,0,spreadAngle)));
                    Instantiate(playerBullet, firePoints[3].position, firePoints[3].rotation * Quaternion.Inverse(Quaternion.Euler(0,0, -spreadAngle)));
                    spreadAngle += 5;
                }
            }
            nextFire = Time.time + 1/fireRate;
        }
        if(Input.GetButton("Fire1") && Time.time > nextRockets)
        {
            if (rocketLevel >= 1)
            {
                int spreadAngle = 5;
                for (int i = 0; i < rocketLevel && i < maxRocketLevel + 1; i++)
                {

                    Instantiate(playerRocket, firePoints[4].position, firePoints[4].rotation * Quaternion.Inverse(Quaternion.Euler(0, 0, spreadAngle)));
                    Instantiate(playerRocket, firePoints[5].position, firePoints[5].rotation * Quaternion.Inverse(Quaternion.Euler(0, 0, -spreadAngle)));
                    spreadAngle += 5;
                }
            }
            nextRockets = Time.time + 1 / rocketFireRate;
        }
    }
    public void upgradeRocketLevel()
    {
        rocketLevel++;
        if(rocketLevel < maxRocketLevel + 1)
        {
            rocketFireRate += 0.1f;
        }
    }
    public void upgradeFireLevel()
    {
        fireLevel++;
        if(fireLevel < maxFireLevel + 1)
        {
            fireRate += 1;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Shoot : MonoBehaviour
{
    public GameObject[] bullets;
    public int fireRate1;
    public Transform[] firePoints;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(fire1), fireRate1, fireRate1);
    }

    private void fire1()
    {
        int spreadAngle = 5;
        for (int i = 0; i < 5; i++)
        {

            Instantiate(bullets[0], firePoints[0].position, firePoints[0].rotation * Quaternion.Inverse(Quaternion.Euler(0, spreadAngle, 0)));
            Instantiate(bullets[0], firePoints[1].position, firePoints[1].rotation * Quaternion.Inverse(Quaternion.Euler(0, -spreadAngle, 0)));
            spreadAngle += 5;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePowerUp : MonoBehaviour
{
    private int speed = 50;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
}

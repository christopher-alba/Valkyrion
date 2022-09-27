using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePowerUp : MonoBehaviour
{
    private float rotateSpeed = 100f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotateSpeed, rotateSpeed, rotateSpeed) * Time.deltaTime);
    }
}

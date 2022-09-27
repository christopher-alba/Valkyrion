using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody rb;
    public Camera MainCamera;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed * 150* Time.deltaTime;
        Destroy(gameObject,3);
    }
}

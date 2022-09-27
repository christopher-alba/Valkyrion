using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public int speed;
    public int rotationAcceleration;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        if (rb.transform.localRotation.x * (360/100) * Mathf.Rad2Deg >= -45 && rb.transform.localRotation.x * (360 / 100) * Mathf.Rad2Deg <= 45)
        {
            rb.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal"), 0) * -rotationAcceleration * 150 * Time.deltaTime);
        }
        
        if (Input.GetAxis("Horizontal") == 0)
        {
            rb.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90f, 180f, 0f), rotationAcceleration * 5 * Time.deltaTime);
        }
    }
}

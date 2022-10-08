using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearShot : MonoBehaviour
{
    public Rigidbody bullet;
    public float speed = 200;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody>();

        Vector3 direction = transform.forward;
        bullet.velocity = direction * speed * 500 * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
        Invoke(nameof(selfDestruct), 5);
      
    }
    private void selfDestruct()
    {
        Instantiate(explosion, bullet.transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject);
    }
}

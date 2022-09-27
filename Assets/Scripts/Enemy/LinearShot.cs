using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearShot : MonoBehaviour
{
    public Rigidbody bullet;
    public float speed = 200;
    public GameObject explosion;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody>();
        player = FindObjectOfType<shipController>()?.transform;
        if (player != null)
        {
            Vector3 direction = player.transform.position - bullet.transform.position;
            bullet.velocity = direction.normalized * speed * 500 * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
            Invoke(nameof(selfDestruct), 5);
        } else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            bullet.velocity = new Vector3(0, 0, -speed);
        }
    }
    private void selfDestruct()
    {
        Instantiate(explosion, bullet.transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject);
    }
}

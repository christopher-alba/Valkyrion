using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SemiHoming : MonoBehaviour
{
    private Rigidbody bullet;
    public float speed = 200;
    public float turnRate = 2;
    public GameObject explosion;
    public bool isTargetingPlayer = true;
    private Transform player;
   
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody>();
        if (isTargetingPlayer)
        {
            player = FindObjectOfType<shipController>()?.transform;
        } else
        {
            //Target a random enemy
            List<EnemyLifeController> objects = FindObjectsOfType<EnemyLifeController>().ToList();
            if (objects.Count > 0)
            {
                player = objects[Random.Range(0, objects.Count)].transform;
            }

        }
   
        transform.rotation = Quaternion.LookRotation(transform.forward, Vector3.up);
        Invoke(nameof(selfDestruct), 4);
    }
    private void selfDestruct()
    {
        Instantiate(explosion, bullet.transform.position, Quaternion.Euler(90, 0, 0));
        Destroy(gameObject);
    }
    private void recalculateTarget()
    {
        List<EnemyLifeController> objects = FindObjectsOfType<EnemyLifeController>().ToList();
        if(objects.Count > 0)
        {
            player = objects[Random.Range(0, objects.Count)].transform;
        }
    }
    private void Update()
    {
        if(player != null)
        {
            /*transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Random.Range(10, 50));*/
            Vector3 direction = player.transform.position - bullet.transform.position;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction, Vector3.up), turnRate * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * speed;
        } else
        {
            transform.position += transform.forward * Time.deltaTime * speed;
            recalculateTarget();
        }
        
    }
}

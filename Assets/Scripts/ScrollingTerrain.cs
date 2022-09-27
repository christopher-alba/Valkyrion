using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollingTerrain : MonoBehaviour
{
    // Start is called before the first frame update
    private int speed = 2000;
    private Transform ground;
    public Transform[] terrains;
    private Vector3 respawnPosition;
    public Camera mainCamera;
    private bool terrainCreated = false;
    void Start()
    {
        ground = GameObject.FindGameObjectsWithTag("Environment")[0].transform;
        float timeToDestroy = 15 + ground.gameObject.GetComponent<MeshRenderer>().bounds.size.z / speed;
        Debug.Log(timeToDestroy);
        Destroy(gameObject,timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        ground = GameObject.FindGameObjectsWithTag("Environment")[GameObject.FindGameObjectsWithTag("Environment").Length - 1].transform;
        respawnPosition = ground.gameObject.GetComponent<BoxCollider>().bounds.max;
        if (mainCamera.WorldToViewportPoint(respawnPosition).y <= 1 && !terrainCreated)
        {
            terrainCreated = true;
            transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
            Instantiate(terrains[Random.Range(0, terrains.Length)],
                new Vector3(respawnPosition.x - ground.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2,
                transform.position.y,
                respawnPosition.z + ground.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2 - 500),
                Quaternion.Euler(0, 90, 0));
        } else
        {
            transform.position -= new Vector3(0, 0, speed * Time.deltaTime);

        }
    }
}

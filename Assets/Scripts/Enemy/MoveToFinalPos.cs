using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToFinalPos : MonoBehaviour
{
    public BoxCollider finalPosBoxCollider;
    public int speed;
    public Camera mainCamera;
    private Transform player;
    private float randomX, randomZ, bossX, bossZ;
    private Vector3 screenBounds;
    
    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<shipController>().transform;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));
        randomX = Random.Range(screenBounds.x * -1 - 550, screenBounds.x + 350);
        randomZ = Random.Range(screenBounds.z * -1 + 200, screenBounds.z + 330);
        bossX = screenBounds.x - 200;
        bossZ = screenBounds.z + 300;


    }
    // Update is called once per frame
 
    void Update()
    {

        if (gameObject.tag.Equals("Boss") )
        {
            if(player != null && transform.position.z > bossZ)
            {
                gameObject.GetComponent<Rigidbody>().velocity = (new Vector3(bossX, player.transform.position.y, bossZ) - gameObject.transform.position).normalized * speed * Time.deltaTime;
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        } else
        {
            if (player != null && transform.position.z > randomZ)

            {

                gameObject.GetComponent<Rigidbody>().velocity = (new Vector3(randomX, player.transform.position.y, randomZ) - gameObject.transform.position).normalized * speed * Time.deltaTime;

            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}

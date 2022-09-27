using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public int speed;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(PlayerPrefab.transform.position.x, gameObject.transform.position.y, PlayerPrefab.transform.position.z + 50), speed);
    }
}

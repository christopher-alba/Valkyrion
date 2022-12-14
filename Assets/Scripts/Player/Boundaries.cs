using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boundaries : MonoBehaviour
{
    private Camera MainCamera;
    public Transform player;
    // Use this for initialization
    void Start()
    {
        player = GetComponent<shipController>().transform;
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (MainCamera != null)
        {
            var playerPosInViewport = MainCamera.WorldToScreenPoint(player.position);
            playerPosInViewport.x = Mathf.Clamp(playerPosInViewport.x, 0, Screen.width);
            playerPosInViewport.y = Mathf.Clamp(playerPosInViewport.y, 0, Screen.height);
            transform.position = Vector3.MoveTowards(transform.position, MainCamera.ScreenToWorldPoint(playerPosInViewport), Time.deltaTime * 10000);
        } else
        {
            MainCamera = Camera.main;
        }
       
    }
}
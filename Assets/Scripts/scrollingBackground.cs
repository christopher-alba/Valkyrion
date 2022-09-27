using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollingBackground : MonoBehaviour
{
    // Update is called once per frame
    public Sprite newSprite;
    public Vector2 speed;
    private Material mat;

    private void Awake()
    {
        mat = gameObject.GetComponent<Image>().material;
    }
    void Update()
    {
        Vector2 offset = speed * Time.deltaTime;
        mat.mainTextureOffset += offset;
    }
}

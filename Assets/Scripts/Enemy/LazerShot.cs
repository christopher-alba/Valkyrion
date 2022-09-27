using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShot : MonoBehaviour
{
    // Start is called before the first frame update
    bool stopLazerVar = false;
    void Start()
    {
        Invoke(nameof(stopLazer), 2);
    }
    private void stopLazer()
    {
        stopLazerVar = true;
        Destroy(gameObject, 1);
    }
    private void Update()
    {
        if (stopLazerVar)
        {
            ParticleSystem.MainModule particleSystem = gameObject.GetComponent<ParticleSystem>().main;
            particleSystem.startSize = Mathf.Lerp(particleSystem.startSize.constant, 0, 2*Time.deltaTime);
        }
    }
}

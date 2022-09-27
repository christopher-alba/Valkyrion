using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelUpController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider collision)
    {
        shipController shipControllerVar = collision.GetComponent<shipController>();
        if (shipControllerVar != null)
        {
            List<Action> functions = new(); 
            if(shipController.instance.rocketLevel < shipController.instance.maxRocketLevel)
            {
                functions.Add(() => shipControllerVar.upgradeRocketLevel());
            }
            if(shipController.instance.fireLevel < shipController.instance.maxFireLevel)
            {
                functions.Add(() => shipControllerVar.upgradeFireLevel());
            }
            int minRange = functions.Count > 0 ? 1 : 0;
            int maxRange = functions.Count + 1;
            int number = Random.Range(minRange,maxRange);
          
            if(number > 0) {
                functions[number - 1].Invoke();
            }
            
           
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No life controller found");
        }
    }
}

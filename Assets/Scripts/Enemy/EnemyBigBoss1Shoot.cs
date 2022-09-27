using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigBoss1Shoot : MonoBehaviour
{
    public Transform[] largeCannonFirepoints;
    public Transform[] cannonFirepoints;
    public GameObject largeCannonProjectile;
    public GameObject cannonProjectile;
    public int largeCannonFireInterval;
    public int cannonFireInterval;

    private void FireLargeCannons()
    {
        StartCoroutine(LargeCannonsFireSequence());
    }
    IEnumerator LargeCannonsFireSequence()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        Instantiate(largeCannonProjectile, largeCannonFirepoints[0].position, largeCannonFirepoints[0].rotation);
        Instantiate(largeCannonProjectile, largeCannonFirepoints[1].position, largeCannonFirepoints[1].rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(largeCannonProjectile, largeCannonFirepoints[2].position, largeCannonFirepoints[2].rotation);
        Instantiate(largeCannonProjectile, largeCannonFirepoints[3].position, largeCannonFirepoints[3].rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(largeCannonProjectile, largeCannonFirepoints[4].position, largeCannonFirepoints[4].rotation);
        Instantiate(largeCannonProjectile, largeCannonFirepoints[5].position, largeCannonFirepoints[5].rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(largeCannonProjectile, largeCannonFirepoints[6].position, largeCannonFirepoints[6].rotation);
        Instantiate(largeCannonProjectile, largeCannonFirepoints[7].position, largeCannonFirepoints[7].rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(largeCannonProjectile, largeCannonFirepoints[8].position, largeCannonFirepoints[8].rotation);
        Instantiate(largeCannonProjectile, largeCannonFirepoints[9].position, largeCannonFirepoints[9].rotation);
    }
    private void FireCannons()
    {
        StartCoroutine(CannonsFireSequence());  
    }

    IEnumerator CannonsFireSequence()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        Instantiate(cannonProjectile, cannonFirepoints[0].position, cannonFirepoints[0].rotation);
        Instantiate(cannonProjectile, cannonFirepoints[1].position, cannonFirepoints[1].rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(cannonProjectile, cannonFirepoints[2].position, cannonFirepoints[2].rotation);
        Instantiate(cannonProjectile, cannonFirepoints[3].position, cannonFirepoints[3].rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(cannonProjectile, cannonFirepoints[4].position, cannonFirepoints[4].rotation);
        Instantiate(cannonProjectile, cannonFirepoints[5].position, cannonFirepoints[5].rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(cannonProjectile, cannonFirepoints[6].position, cannonFirepoints[6].rotation);
        Instantiate(cannonProjectile, cannonFirepoints[7].position, cannonFirepoints[7].rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(cannonProjectile, cannonFirepoints[8].position, cannonFirepoints[8].rotation);
        Instantiate(cannonProjectile, cannonFirepoints[9].position, cannonFirepoints[9].rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(cannonProjectile, cannonFirepoints[10].position, cannonFirepoints[10].rotation);
        Instantiate(cannonProjectile, cannonFirepoints[11].position, cannonFirepoints[11].rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(cannonProjectile, cannonFirepoints[12].position, cannonFirepoints[12].rotation);
        Instantiate(cannonProjectile, cannonFirepoints[13].position, cannonFirepoints[13].rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(cannonProjectile, cannonFirepoints[14].position, cannonFirepoints[14].rotation);
        Instantiate(cannonProjectile, cannonFirepoints[15].position, cannonFirepoints[15].rotation);
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(FireLargeCannons), largeCannonFireInterval, largeCannonFireInterval);
        InvokeRepeating(nameof(FireCannons), cannonFireInterval, cannonFireInterval);
    }

    // Update is called once per frame
}

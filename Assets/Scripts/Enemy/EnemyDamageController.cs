using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;
    public GameObject explosion;
    private void OnTriggerEnter(Collider collision)
    {
        PlayerLifeController lifeController = collision.GetComponent<PlayerLifeController>();
        GameObject collisionObject = collision.gameObject;
        if (lifeController != null)
        {
            if (collisionObject.name.Contains("Player") && gameObject.name.Contains("Enemy"))
            {
                lifeController.TakeDamage(damage);
                ScoreManager.instance.decrementPlayerScoreMultiplier();
                if (gameObject.name.Contains("Lazer"))
                {
                    /*Vector3 collisionObjectBoundsMin = collision.bounds.min;
                    Vector3 collisionObjectBoundsMax = collision.bounds.max;
                    float minX = collisionObjectBoundsMin.x;
                    float maxX = collisionObjectBoundsMax.x;
                    float minZ = collisionObjectBoundsMin.z;
                    float maxZ = collisionObjectBoundsMax.z;    
                    explosion.GetComponent<SpriteRenderer>().color = Color.blue;
                    Instantiate(explosion, new Vector3 (Random.Range(minX,maxX) , collision.transform.position.y , Random.Range(minZ,maxZ)), Quaternion.Euler(90, 0, 0));*/
                }
                else
                {
                    Instantiate(explosion, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
                    Destroy(gameObject);
                }



            }
        }
    }
}

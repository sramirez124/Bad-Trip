using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //! make this modular so one script damages both enemy and player
    private void OnCollisionEnter(Collision collision) 
    {
        Transform hitTransform = collision.transform;
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(1);
        }
        else
            Debug.Log("Hit Enemy Part " + collision.transform.name);
            hitTransform.GetComponent<EnemyHealth>().TakeDamage(1);
        Destroy(gameObject);
    }
}

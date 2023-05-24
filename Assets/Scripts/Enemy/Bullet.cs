using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //! make this modular so one script damages both enemy and player
    private void OnCollisionEnter(Collision collision) 
    {
        string transformName = collision.transform.name;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerHealth>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        else
            //Debug.Log("Hit " + transformName);
            collision.transform.GetComponent<EnemyHealth>().TakeDamage(1, transformName);
            Destroy(this.gameObject);
    }
}

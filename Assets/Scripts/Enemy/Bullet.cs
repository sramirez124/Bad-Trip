using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) 
    {
        Transform hitTransform = collision.transform;
        if (hitTransform = collision.transform)
        {
            Debug.Log("Hit Player");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(1);
        }
        Destroy(gameObject);
    }
}

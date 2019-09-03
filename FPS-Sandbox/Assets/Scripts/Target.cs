using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject destroyedVersion;
    public GameObject explosionEffect;

    [SerializeField] public float health;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Destruction();
        }
    }

    public void Destruction()
    {
        if(destroyedVersion != null)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
        }
        if(explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, 2.0f);
        }
        
        Destroy(gameObject);
    }
}

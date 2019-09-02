using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] public float delay;
    [SerializeField] public float radius;
    [SerializeField] public float force;
    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    private void Explode()
    {
        //Effect
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);

        //Get nearby object to push them and inflict damages
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObjects in collidersToDestroy)
        {
            Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            //Damages
            Target target = nearbyObjects.GetComponent<Target>();
            if(target != null)
            {
                target.Destruction();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObjects in collidersToMove)
        {
            Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(explosion, 2.0f);

        //Remove grenade
        Destroy(gameObject);
    }
}

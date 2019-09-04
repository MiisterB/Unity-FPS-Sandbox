using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTurret : MonoBehaviour
{
    public SphereCollider playerDetector;
    public Transform rotationPoint;
    public Transform playerPosition;

    // Update is called once per frame
    void Update()
    {
        if(playerPosition != null)
        {
            RotateToPlayer();
        }
    }

    void RotateToPlayer()
    {

    }
    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag.Equals("Player"))
        {
            playerPosition = collider.GetComponent<Transform>();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag.Equals("Player"))
        {
            playerPosition = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    //Configuration parameters
    public Transform target;
    private Rigidbody rigidbody;
    public float speed;
    public float rotateSpeed;
    public bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {

            Vector3 direction = target.position - rigidbody.position;
            direction.Normalize();
            Vector3 roatateAmount = Vector3.Cross(direction, transform.up);
            rigidbody.angularVelocity = -roatateAmount * rotateSpeed;
            rigidbody.velocity = transform.up * speed;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public bool BulletIsDestroyed()
    {
        return isDestroyed;
    }
}

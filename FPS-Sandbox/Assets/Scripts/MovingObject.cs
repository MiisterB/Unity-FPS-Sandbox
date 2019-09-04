using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] public List<Transform> waypoints;
    [SerializeField] public float speed;
    public int waypointIndex = 0;
    public bool activateMovement = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            activateMovement = true;
        }

        if(activateMovement)
        {
            MoveObject();
        }
        
    }

    void MoveObject()
    {
        if(waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
    }
}

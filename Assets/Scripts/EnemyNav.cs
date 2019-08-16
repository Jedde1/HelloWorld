using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public Transform waypointParent;
    public float speed = 5f;
    public float waypointDistance = 5;
    private Transform[] points;
    private int currentWaypoint = 1;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        points = waypointParent.GetComponentsInChildren<Transform>();
    }

    void OnDrawGizmos()
    {
        if (points != null)
        {
            Gizmos.color = Color.blue;
            for (int i = 1; i < points.Length - 1; i++)
            {
                Transform pointA = points[i];
                Transform pointB = points[i + 1];
                Gizmos.DrawLine(pointA.position, pointB.position);
            }

            foreach (var point in points)
            {
                Gizmos.DrawSphere(point.position, waypointDistance);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Get the current Waypoint
        Transform currentPoint = points[currentWaypoint];
        //Move towards current waypoint
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);
        //check if distance between waypoint is close
        float distance = Vector3.Distance(transform.position, currentPoint.position);
        if (distance < waypointDistance)
        //switch to next waypoint
        {
            currentWaypoint++;
        }

        //>>ERROR HANDLING<<

        //If currentWaypoint is outside array length
        //reset back to 1
        if (currentWaypoint > points.Length - 1)
        {
            currentWaypoint = 1;
        }
    }
}
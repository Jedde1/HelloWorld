using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    //Allows the use of waypoints
    public Transform waypointParent;
    //Speed of the AI
    public float speed = 5f;
    //The amount of space for waypoint leniency
    public float waypointDistance = 5;
    private Transform[] points;
    private int currentWaypoint = 1;
    //unlocks the NavMesh for walkable surfaces
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
                //Moves AI to points
                Transform pointA = points[i];
                Transform pointB = points[i+1];
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
        //transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);
        agent.SetDestination(currentPoint.position);
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

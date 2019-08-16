using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform repspawnPoint;
    public float threshold;
    void FixedUpdate()
    {
        //Allows the possiblity of respawn
        if (transform.position.y < threshold)
            transform.position = repspawnPoint.position;
    }
}

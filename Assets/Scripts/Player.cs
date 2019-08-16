using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    {
    //Access Spec   Data Type   Variable Name   End
    public          Rigidbody   rb              ;
    public float speed = 5f;
    // Update is called once per frame
    void Update()
    {
        //Get input axis from user
        //Allows the player to Move
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(inputH, 0, inputV);
        rb.AddForce(direction * speed);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnTriggerEvent : MonoBehaviour
{
    public UnityEvent onEnter;
    public string hitTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        //Triggers events for unlocking the door
        if (other.tag == hitTag)
        {
            onEnter.Invoke();
        }
    }
}

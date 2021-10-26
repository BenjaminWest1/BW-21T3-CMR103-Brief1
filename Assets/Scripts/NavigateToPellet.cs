using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateToPellet : MonoBehaviour
{
    public TurtleMovement turtleMovementScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pellet"))
        {
            Vector3 pellet = other.gameObject.GetComponent<Transform>().position;
            turtleMovementScript.TurtleSwim(pellet, true);
        }
    }
}

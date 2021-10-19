using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateToPellet : MonoBehaviour
{
    public GameObject turtleMovementScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pellet"))
        {
            
        }
    }
}

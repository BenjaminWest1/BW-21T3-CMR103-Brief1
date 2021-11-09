using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateToPellet : MonoBehaviour
{
    public TurtleMovement turtleMovementScript;

    public AudioClip plopSound;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Pellet"))
        {
            AudioSource audioSource = other.GetComponent<AudioSource>();
            audioSource.clip = plopSound;
            audioSource.Play();

            Vector3 pellet = other.gameObject.GetComponent<Transform>().position;
            turtleMovementScript.TurtleSwim(pellet, true);
        }
    }
}

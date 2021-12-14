using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationCube : MonoBehaviour
{
    private int handsInside = 0;
    public GameObject gameObject;
    public Renderer r;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RightControllerAnchor" || other.gameObject.name == "LeftControllerAnchor")
        {
            r.enabled = true;
            handsInside++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RightControllerAnchor" || other.gameObject.name == "LeftControllerAnchor")
        {
            handsInside--;
            if (handsInside == 0)
            {
                r.enabled = false;
            }
        }
    }
}

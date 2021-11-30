using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationCube : MonoBehaviour
{
    private int handsInside = 0;
    public GameObject gameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RightControllerAnchor" || other.gameObject.name == "LeftControllerAnchor")
        {
            gameObject.SetActive(true);
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
                gameObject.SetActive(false);
            }
        }
    }
}

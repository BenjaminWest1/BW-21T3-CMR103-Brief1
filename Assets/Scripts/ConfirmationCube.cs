using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationCube : MonoBehaviour
{
    private int handsInside = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (hand.gameObject.name == "RightControllerAnchor" || hand.gameObject.name == "LeftControllerAnchor")
        {
            this.SetActive(true);
            handsInside++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (hand.gameObject.name == "RightControllerAnchor" || hand.gameObject.name == "LeftControllerAnchor")
        {
            handsInside--;
            if (handsInside == 0)
            {
                this.SetActive(false);
            }
        }
    }
}

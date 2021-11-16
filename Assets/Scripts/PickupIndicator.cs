using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupIndicator : OVRGrabbable
{
    AudioSource audioSource;
    public AudioClip pickupSound;
    OVRHapticsClip ovrClip;

    // Start is called before the first frame update
    protected override void Start()
    {

        audioSource = GetComponent<AudioSource>();

        ovrClip = new OVRHapticsClip(pickupSound);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        Debug.Log("This is being called");

        base.GrabBegin(hand, grabPoint);
        //now do the things I want to do

        audioSource.clip = pickupSound;
        audioSource.Play();

        if (hand.gameObject.name == "RightControllerAnchor")
        {
            OVRHaptics.RightChannel.Preempt(ovrClip);
        }
        else if (hand.gameObject.name == "LeftControllerAnchor")
        {
            OVRHaptics.LeftChannel.Preempt(ovrClip);
        }
    }


    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
    }
}

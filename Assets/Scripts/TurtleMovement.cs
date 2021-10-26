using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    public float xPoolUpper = 3.8f;
    public float yPoolUpper = -0.25f;
    public float zPoolUpper = 3.8f;
    public float xPoolLower = 0.2f;
    public float yPoolLower = -0.55f;
    public float zPoolLower = 0.2f;
    public float idleWait = 5.0f;
    public float speed = 0.1f;

    public bool inMotion = false;
    //public bool triggerMotion = false;
    public bool endPosSet = false;

    //private float startTime;
    private float distanceToCover;

    private Vector3 startPos;
    private Vector3 endPos;

    private Quaternion lookRotation;
    private Vector3 direction;
    private float rotationSpeed = 1.0f;

    public PelletManager pelletManager;

    // Update is called once per frame
    void Update()
    {
        TurtleSwim(new Vector3(0, 0, 0), false);
    }

    public void TurtleSwim(Vector3 pointToMoveTo, bool food)
    {
        idleWait -= Time.deltaTime;
        startPos = transform.position;
        //Debug.Log(distanceToCover);

        if (food == true)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            startPos = transform.position;
            endPos = pointToMoveTo;
            endPosSet = true;
            inMotion = true;
        }

        distanceToCover = Vector3.Distance(startPos, endPos);

        if (distanceToCover < 0.1f && inMotion == true)
        {
            inMotion = false;
            idleWait = Random.Range(2.0f, 8.0f);
            endPosSet = false;
        }

        if (idleWait <= 0.0f && endPosSet == false)
        {
            startPos = transform.position;
            endPos.x = Random.Range(xPoolLower, xPoolUpper);
            endPos.y = Random.Range(yPoolLower, yPoolUpper);
            endPos.z = Random.Range(zPoolLower, zPoolUpper);
            //Debug.Log(endPos);
            //startTime = Time.time;
            inMotion = true;
            //triggerMotion = true;
            endPosSet = true;
        }

        if (inMotion == true) //&& triggerMotion == true)
        {
            //triggerMotion = false;
            if (distanceToCover > 0.1f)
            {
                //find the vector pointing from our position to the target
                direction = (endPos - transform.position).normalized;

                //create the rotation we need to be in to look at the target
                lookRotation = Quaternion.LookRotation(direction);

                //rotate us over time according to speed until we are in the required rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

                //transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
                //transform.LookAt(endPos);

                // Distance moved equals elapsed time times speed..
                //float distCovered = (Time.time - startTime) * speed;

                // Fraction of journey completed equals current distance divided by total distance.
                //float fractionOfJourney = distCovered / distanceToCover;

                // Set our position as a fraction of the distance between the markers.
                transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * speed);
            }


            //float time = 0;

            //while (time < distanceToCover)
            //{
            //transform.position = Vector3.Lerp(startPos, endPos, time / distanceToCover);
            //time += Time.deltaTime;
            //}
            //transform.position = endPos;

            // Distance moved equals elapsed time times speed..
            //float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            //float fractionOfJourney = distCovered / distanceToCover;

            // Set our position as a fraction of the distance between the markers.
            //transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pellet"))
        {
            pelletManager.PelletRespawn();
        }
    }
}

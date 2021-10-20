using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    public float xPool = 4.0f;
    public float yPool = 0.5f;
    public float zPool = 4.0f;
    public float idleWait = 5.0f;
    public float speed = 1.0f;

    public bool inMotion = false;

    private float startTime;
    private float distanceToCover;

    private Vector3 startPos;
    private Vector3 endPos = new Vector3 (0, -0.5f, 0);

    // Update is called once per frame
    void Update()
    {
        idleWait -= Time.deltaTime;

        if (endPos == transform.position && inMotion == true)
        {
            inMotion = false;
            idleWait = Random.Range(2.0f, 8.0f);
        }

        if (idleWait <= 0.0f)
        {
            startPos = transform.position;
            endPos.x = Random.Range(0.0f, xPool);
            endPos.y = Random.Range(-yPool - 1.0f, -yPool);
            endPos.z = Random.Range(0.0f, zPool);
            distanceToCover = Vector3.Distance(startPos, endPos);
            startTime = Time.time;
            inMotion = true;
        }

        if (inMotion == true)
        {
            //transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            //float time = 0;

            //while (time < distanceToCover)
            //{
            //transform.position = Vector3.Lerp(startPos, endPos, time / distanceToCover);
            //time += Time.deltaTime;
            //}
            //transform.position = endPos;

            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / distanceToCover;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
        }
    }

    //public TurtleSwim(Vector3 pointToMoveTo, bool inMotion)
    //{
        //if (idleWait <= 0.0f)
        //{
            //new Vector3 startPos = this.transform;
            //inMotion = true;
        //}

        //if (inMotion == true)
        //{
            // Distance moved equals elapsed time times speed..
            //float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            //float fractionOfJourney = distCovered / distanceToCover;

            // Set our position as a fraction of the distance between the markers.
            //transform.position = Vector3.Lerp(star, endMarker.position, fractionOfJourney);
        //}
    //}
}

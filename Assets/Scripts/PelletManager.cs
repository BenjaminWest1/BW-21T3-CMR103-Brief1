using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletManager : MonoBehaviour
{
    public GameObject respawnPellet;
    public Vector3 respawnPelletPoint;
    public ConfirmationCube cube;

    // Start is called before the first frame update
    void Start()
    {
        if (respawnPellet != null)
        {
            respawnPelletPoint = respawnPellet.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PelletRespawn()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.transform.position = respawnPelletPoint;
        cube.handsInside = 0;
    }
}

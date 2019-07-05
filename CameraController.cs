using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Enables the camera to follow and track the player as they progress */
public class CameraController : MonoBehaviour {

    public Controller thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;
    
    /* Locate the player */
    void Start () {
        thePlayer = FindObjectOfType<Controller>();
        lastPlayerPosition = thePlayer.transform.position;		
	}
	

    /* Follow the player */
    void Update () {

        distanceToMove = thePlayer.transform.position.y - lastPlayerPosition.y;

        transform.position = new Vector3(transform.position.x, transform.position.y + distanceToMove, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;	
	}
}

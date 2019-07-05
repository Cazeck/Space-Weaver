using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles movement for the Alien object within the game. Simplified version of PlayerMovement.  Needs to be cleaned up
   Moves the same way as the user except the alien is never given a controller, so it just moves forward */
public class AlienMovement : MonoBehaviour {

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;
    public static event PlayerDelegate OnPlayerScored;

    public float maxSpeed = 4;
    public float rotSpeed = 180f;

    public float maxY;
    public float currentY;
    public bool scoreEnable;

    public float scoreRangeLow;
    public float scoreRangeHigh;

    float ScreenWidth;

    public bool movement;
    public bool moveRight;
    public bool moveLeft;

    public Vector3 startPos;
    public Quaternion startRot;

    ScoreManager theScoreManager;
    GameManager game;

    /* Set the initial position for the ship */
    void Start() {
        maxY = transform.localPosition.y;
        startPos = transform.localPosition;
        startRot = transform.localRotation;
        game = GameManager.Instance;
        theScoreManager = FindObjectOfType<ScoreManager>();
        movement = false;
        ScreenWidth = Screen.width;
     }

    /* Start moving forward on game start */
    void OnEnable() {
        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
    }

    /* Stop moving when game ends */
    void OnDisable() {
        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
    }

    /* Start moving forward on game start */
    void OnGameStarted() {
        //rigidbody.velocity = Vector3.zero;
        scoreRangeLow = 0;
        scoreRangeHigh = 100;
        movement = true;
    }

    /* Reset initial position of the ship */
    void OnGameOverConfirmed() {
        transform.localPosition = startPos;
        transform.localRotation = startRot;
    }

    // Update is called once per frame
    void Update() {

        if (movement == true) {

            currentY = transform.localPosition.y;

            Vector3 pos = transform.position;
            Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

            Quaternion rot = transform.rotation;
            float z = rot.eulerAngles.z;

            pos += rot * velocity;

            transform.position = pos;

        }
    }
}
            /* 

            if (maxY < currentY) {
                maxY = currentY;
                scoreEnable = true;
            }

            else {
                scoreEnable = false;
            }

            // ROTATE the ship.
            // Grab rotation quaternion
            // grab the z euler angle, change, recreate quaterion, and feed into rotation
            // find a way to change this so that it's left side vs right side
            // MOVE the ship

            Quaternion rot = transform.rotation;
            float z = rot.eulerAngles.z;

            int i = 0;

            if (moveRight == true) {
                z -= 1f * rotSpeed * Time.deltaTime;
                rot = Quaternion.Euler(0, 0, z);
                transform.rotation = rot;
            }

            if (moveLeft == true) {
                z -= -1f * rotSpeed * Time.deltaTime;
                rot = Quaternion.Euler(0, 0, z);
                transform.rotation = rot;
            }

            //z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

            Vector3 pos = transform.position;
            Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

            pos += rot * velocity;

            transform.position = pos;

        }
    }

    public void OnPointerDownRight() { moveRight = true; }

    public void OnPointerUpRight() { moveRight = false; }

    public void OnPointerDownLeft() { moveLeft = true; }

    public void OnPointerUpLeft() { moveLeft = false; }


    void OnTriggerEnter2D(Collider2D col)
    {
        print(col.gameObject.tag);
        //if (col.gameObject.tag == "Score Zone")
        //{
        // register a score event
        //  OnPlayerScored(); //event sent to GameManager
        // play a sound
        // scoreAudio.Play();
        // }

        if (col.gameObject.tag == "Dead Zone" || col.gameObject.tag == "DeadZone")
        {
            //new WaitForSeconds(2);

            movement = false;
            moveLeft = false;
            moveRight = false;
            maxY = 0;

            // register a dead event
            //maxVelocityY = 4f;
            OnPlayerDied(); //event sent to game manager
                            
			// play a sound
            //dieAudio.Play();
        }
    }  */


// }

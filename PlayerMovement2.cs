using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles movement for the Player (Rocket) */
public class PlayerMovement2 : MonoBehaviour {

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

    Vector2 ScreenSize;
    float ScreenWidth;

    public bool movement;
    public bool moveRight;
    public bool moveLeft;

    public Vector3 startPos;
    public Quaternion startRot; 

	public AudioSource dieAudio;
    public AudioSource coinAudio;

    ScoreManager theScoreManager;
    //LevelGenerator theLevel;
    GameManager game;
    TrailRenderer trail;
    CameraCollision cameraCollision;

    /* Initialize original position, etc */
    void Start () {
        maxY = transform.localPosition.y;
        startPos = transform.localPosition;
        startRot = transform.localRotation;
        game = GameManager.Instance;
        theScoreManager = FindObjectOfType<ScoreManager>();
        cameraCollision = FindObjectOfType<CameraCollision>();
        trail = FindObjectOfType<TrailRenderer>();
        movement = false;
        ScreenWidth = Screen.width;		
	}

    void OnEnable()
    {
        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
    }

    void OnDisable()
    {
        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
    }

    /* Set score to 0 and enable player movement */
    void OnGameStarted()
    {
        scoreRangeLow = 0;
        scoreRangeHigh = 100;
        movement= true;
    }

    /* Reset original position */
    void OnGameOverConfirmed()
    {
        transform.localPosition = startPos;
        transform.localRotation = startRot;
    }

    /* Updated once per frame */
    void Update() {

        if (movement == true) {

            currentY = transform.localPosition.y;

            /* If moving forward and past the farthest point you've been, allow points */
            if (maxY < currentY) {
                maxY = currentY;
                scoreEnable = true;
            }
            else {
                scoreEnable = false;
            }

            /* Rotate the ship
             * Grab the rotation quaternion, z euler angle, change it,  recreate quaterion, and feed it into rotation
             */

            Quaternion rot = transform.rotation;
            float z = rot.eulerAngles.z;

            if (moveRight == true ) {
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

    /* Set the trail size and lenght (Fire behind ship) */
    public void ResetTrailRender() {
        float trailTime = .125f;
        trail.time = trailTime;
    }

   
    void OnTriggerEnter2D(Collider2D col) {
        print(col.gameObject.tag);
        
        // Play sound when coin in picked up and add it to the users total
        if (col.gameObject.tag == "PickUp") {
            coinAudio.Play();
            col.gameObject.SetActive(false);

            game.coinsEarned += 1; 
        }

        // If a Dead Zone is hit, stop movement and end the game
        if (col.gameObject.tag == "Dead Zone" || col.gameObject.tag == "DeadZone") {

            movement = false;
            moveLeft = false;
            moveRight = false;
            maxY = 0;
            OnPlayerDied();		 //event sent to game manager
            dieAudio.Play();
        }

        // If either edge of the screen is hit, come out of the other side
        if (col.gameObject.tag == "Left Zone" || col.gameObject.tag == "Right Zone")
        {
            if (col.gameObject.tag == "Left Zone")
            {
                Vector3 pos = transform.position;
                Vector3 xChange = new Vector3(cameraCollision.rightCollider.x, 0, 0);

                pos += xChange * 1.85f;

                float trailTime = trail.time; // To fix trail glitching while teleporting
                //ResetTrailRender();         // Sets trail to zero then yields for a second
                trail.time = 0;                   
                
                
                transform.position = pos;
                Invoke("ResetTrailRender", .1f);
                //trail.time = trailTime;       // Reset to normal value
            }

            if (col.gameObject.tag == "Right Zone")
            {
                Vector3 pos = transform.position;
                Vector3 xChange = new Vector3(cameraCollision.leftCollider.x, 0, 0);

                pos += xChange * 1.85f;

                float trailTime = trail.time; // To fix trail glitching while teleporting
                trail.time = 0;               

                //ResetTrailRender();

                transform.position = pos;
                Invoke("ResetTrailRender", .1f);
            }
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generates the level upon starting as well as destroys it when game finishes.  Also this is where the manipulation of level difficulty is. 

/*
 *  Generates the level when game starts
 *  Destroys the level when game ends
 *  Difficulty of the level generated also determined here
 */
public class LevelGenerator : MonoBehaviour {

    class PoolObject {
        public Transform transform;
        public bool inUse;
        public PoolObject(Transform t) { transform = t; }
        public void Use() { inUse = true; }
        public void Dispose() { inUse = false; }
    }

    public GameObject platformPrefab;
    public delegate void LevelDelegate();
    public static event LevelDelegate LevelGenerated;

    Spin spinSpeed;
    GameObject newRock;
    GameObject[] rocksToDestroy;
    GameObject[] rocksToRemove;

    public float currentYPos;
    public float ySpawnTrigger;
    public float ySpawnDist;
    public float yDeSpawnTrigger;
    public float yDeSpawnDist;

    public float yDifficultyTrigger;
    public float yDifficultyDist;
    public int rockIncreaseRate;

    public int numberOfRocks;
    public int maxRocks;

    public float levelWidth = 3f;
    public float minY = .5f;
    public float maxY = 2f;

    PlayerMovement2 Rocket;

    void Start() {}

    void Update() {

        // Determine where the player is and find their y position
        Rocket = FindObjectOfType<PlayerMovement2>();
        currentYPos = Rocket.transform.position.y;

        // Handles the difficulty of the game, depends on the values set in Unity. 
        // Ups the amount of rocks generated and/or the frequency generated
        if ((yDifficultyTrigger < currentYPos) && (numberOfRocks < maxRocks)) {
            numberOfRocks += rockIncreaseRate;
            yDifficultyTrigger += yDifficultyDist;
        }
            
        // Spawn additional rocks if trigger is passed, then move the trigger further ahead in the game
        if (ySpawnTrigger < currentYPos) {
            Spawn();
            ySpawnTrigger += ySpawnDist;
        }

        // Remove a segment of the rocks behind the player after the trigger is hit,  move next trigger up
        if (yDeSpawnTrigger < currentYPos) {
            DeSpawn();
            yDeSpawnTrigger += yDeSpawnDist;
        }
    }

    /*  Called when the game starts as well as when spawnTrigger is hit
     *  Randomly generates rocks ahead of the player depending on values set in Unity
     *  Adds random rotation to each rock and labels them as Dead Zones 
     */
    void Spawn() {

        Vector3 spawnPosition = new Vector3();
        spinSpeed = FindObjectOfType<Spin>();
        System.Random rand = new System.Random();

        // + 10f is to push next spawn above the player 
        spawnPosition.y += currentYPos + 10f;

        for (int i = 0; i < numberOfRocks; i++) {
            spinSpeed.speed = rand.Next(50, 300);
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject newRock = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            newRock.tag = "DeadZone";
        }
    }

    /* Called after deSpawnTrigger is hit, removes all rocks 10f behind the player */
    void DeSpawn() {
        rocksToRemove = GameObject.FindGameObjectsWithTag("DeadZone");
        for (var i = 0; i < rocksToRemove.Length; i++) {

            if (rocksToRemove[i].transform.position.y < (currentYPos - 10f)) {
                Destroy(rocksToRemove[i]);
            }
        }
    }

    /* Called after the player dies in the game. Removes the rocks generated within the previous game */
    public void DestroyAllGameObjects()
    {
        rocksToDestroy = GameObject.FindGameObjectsWithTag("DeadZone");

        for (var i = 0; i < rocksToDestroy.Length; i++)
        {         
            Destroy(rocksToDestroy[i]);
        }
    }  
}

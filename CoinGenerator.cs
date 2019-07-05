using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Generates the coins upon starting as well as destroys them when game finishes
   Similar to LevelGenerator, can manipulate how many and how often */

public class CoinGenerator : MonoBehaviour {

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
    GameObject newCoin;
    GameObject[] coinsToDestroy;
    GameObject[] coinsToRemove;

    public float currentYPos;
    public float ySpawnTrigger;
    public float ySpawnDist;
    public float yDeSpawnTrigger;
    public float yDeSpawnDist;

    public float yDifficultyTrigger;
    public float yDifficultyDist;
    public int coinIncreaseRate;

    public int numberOfCoins;
    public int maxCoins;

    public float levelWidth = 2.9f;
    public float minY = .5f;
    public float maxY = 2f;

    PlayerMovement2 Rocket;

    void Start() {}

    void Update() {

        Rocket = FindObjectOfType<PlayerMovement2>();
        currentYPos = Rocket.transform.position.y;

        if ((yDifficultyTrigger < currentYPos) && (numberOfCoins < maxCoins)) {
            numberOfCoins += coinIncreaseRate;
            yDifficultyTrigger += yDifficultyDist;
        }
            
        if (ySpawnTrigger < currentYPos) {
            Spawn();

            ySpawnTrigger += ySpawnDist;
        }

        if (yDeSpawnTrigger < currentYPos) {
            DeSpawn();
            yDeSpawnTrigger += yDeSpawnDist;
        }

    }

    /* Generates the coins in random positions */
    void Spawn() {

        Vector3 spawnPosition = new Vector3();
        //spinSpeed = FindObjectOfType<Spin>();
        System.Random rand = new System.Random();

        // + 10f is to push next spawn above the player 
        spawnPosition.y += currentYPos + 10f;

        for (int i = 0; i < numberOfCoins; i++) {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject newCoin = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            newCoin.tag = "PickUp";
        }
    }

    
    /* Removes the coins  */
    void DeSpawn() {
        coinsToRemove = GameObject.FindGameObjectsWithTag("PickUp");
        for (var i = 0; i < coinsToRemove.Length; i++) {

            if (coinsToRemove[i].transform.position.y < (currentYPos - 10f)) {
                Destroy(coinsToRemove[i]);
            }
        }
    }


    /* Removes any leftover coins */
    public void DestroyAllGameObjects()
    {
        coinsToDestroy = GameObject.FindGameObjectsWithTag("PickUp");

        for (var i = 0; i < coinsToDestroy.Length; i++)
        {         
            Destroy(coinsToDestroy[i]);
        }
    }  
}

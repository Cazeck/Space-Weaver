using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Handles keeping track of the score as the player progresses */
public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text endText;
    public float scoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;

    PlayerMovement2 playMove;

	/* Initialize  */
	void Start () {
        scoreIncreasing = false;
        playMove = FindObjectOfType<PlayerMovement2>();
    }
	
	/* Called once per frame, updates the score as the player progresses */
	void Update () {

        if ( scoreIncreasing && playMove.scoreEnable ) {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

		scoreText.text = "" + Mathf.Round(scoreCount);
        endText.text = "" + Mathf.Round(scoreCount);
	}
}

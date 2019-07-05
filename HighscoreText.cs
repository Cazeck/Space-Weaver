using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

/*
 * Simply displays the user's highest score acheived 
 */

public class HighscoreText : MonoBehaviour {

    Text highscore;

    void OnEnable(){
        highscore = GetComponent<Text>();
        highscore.text = "Best: " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}

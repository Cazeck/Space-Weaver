using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Displays the number of coins the user possesses */
public class CoinText : MonoBehaviour {

    Text coinscore;
    Text coinsEarned;
 
	void Update() {
        coinscore = GetComponent<Text>();
        coinscore.text = " " + PlayerPrefs.GetInt("Coins").ToString();
    }
}

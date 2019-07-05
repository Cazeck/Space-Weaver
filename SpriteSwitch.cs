using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles the ability for the user to switch ships */
public class SpriteSwitch : MonoBehaviour {

	public Sprite shipOne;
	public Sprite shipTwo;
	public Sprite shipThree;
	public Sprite shipFour;
	public Sprite shipFive;

    public AudioSource selected;

	enum SpriteState{
		One,
		Two,
		Three,
		Four,
		Five
	}

	/* Initially start with default ship */
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = shipOne;        
	}

	public void shipOneClicked() {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = shipOne;
        selected.Play();
    }

	public void shipTwoClicked() {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = shipTwo;
        selected.Play();
    }

	public void shipThreeClicked() {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = shipThree;
        selected.Play();
    }

	public void shipFourClicked() {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = shipFour;
        selected.Play();
    }

	public void shipFiveClicked() {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = shipFive;
        selected.Play();
    }
}

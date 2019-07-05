using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles the ability for the user to switch backgrounds */
public class BackgroundSwitch : MonoBehaviour {

    public Sprite currentStart;

    public Sprite spaceOne;
    public Sprite spaceTwo;
    public Sprite spaceThree;
    public Sprite spaceFour;
    public Sprite spaceFive;
    public Sprite spaceSix;

    public AudioSource selected;

    /* public Sprite spaceSeven;
    public Sprite spaceEight;
    public Sprite spaceNine;
    public Sprite spaceTen; */

    enum SpriteState
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six
        /* Seven,
        Eight,
        Nine,
        Ten */
    }
    
    /* Initially start with default space, switch when another is chosen */
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = currentStart;
    }

    public void spaceOneClicked()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceOne;
        currentStart = spaceOne;
        selected.Play();
    }

    public void spaceTwoClicked()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceTwo;
        currentStart = spaceTwo;
        selected.Play();
    }

    public void spaceThreeClicked()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceThree;
        currentStart = spaceThree;
        selected.Play();
    }

    public void spaceFourClicked()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceFour;
        currentStart = spaceFour;
        selected.Play();
    }

    public void spaceFiveClicked()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceFive;
        currentStart = spaceFive;
        selected.Play();
    }

    public void spaceSixClicked()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceSix;
        currentStart = spaceSix;
        selected.Play();
    }

    /* 
    public void spaceSevenClicked()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceSeven;
    }

    public void spaceEightClicked()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceEight;
    }

    public void spaceNineClicked()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceNine;
    }

    public void spaceTenClicked()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceTen;
    }
    */
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Handles the entire Store feature of the game 
 * Keep track of how many coins the user has collected via gameplay
 * Allows user to unlock features with coins 
 * Remember what the user bought so they dont need to repurchase
*/

public class Store : MonoBehaviour {

    int coinTotal;
    bool[] shipsSold;
    bool[] scenesSold;

    // Button Objects for each page in the Store
    public Button buyShip2;
    public Button buyShip3;
    public Button buyShip4;
    public Button buyShip5;
    
    public Toggle ship2;
    public Toggle ship3;
    public Toggle ship4;
    public Toggle ship5;

    // Button Objects for each scene in the Store
    public Button buyScene2;
    public Button buyScene3;
    public Button buyScene4;
    public Button buyScene5;
    public Button buyScene6;

    public Toggle scene2;
    public Toggle scene3;
    public Toggle scene4;
    public Toggle scene5;
    public Toggle scene6;

    public AudioSource locked;
    public AudioSource purchased;

    /* check whether or not a user has purchased an item. If not lock it until purchased  */
    void Start () {

        if (PlayerPrefs.GetInt("shipTwoSold") == 1) {
            buyShip2.gameObject.SetActive(false);
            ship2.interactable = true;
        }

        if (PlayerPrefs.GetInt("shipThreeSold") == 1) {
            buyShip3.gameObject.SetActive(false);
            ship3.interactable = true;
        }

        if (PlayerPrefs.GetInt("shipFourSold") == 1) {
            buyShip4.gameObject.SetActive(false);
            ship4.interactable = true;
        }

        if (PlayerPrefs.GetInt("shipFiveSold") == 1) {
            buyShip5.gameObject.SetActive(false);
            ship5.interactable = true;
        }

        if (PlayerPrefs.GetInt("sceneTwoSold") == 1) {
            buyScene2.gameObject.SetActive(false);
            scene2.interactable = true;
        }

        if (PlayerPrefs.GetInt("sceneThreeSold") == 1) {
            buyScene3.gameObject.SetActive(false);
            scene3.interactable = true;
        }

        if (PlayerPrefs.GetInt("sceneFourSold") == 1) {
            buyScene4.gameObject.SetActive(false);
            scene4.interactable = true;
        }

        if (PlayerPrefs.GetInt("sceneFiveSold") == 1) {
            buyScene5.gameObject.SetActive(false);
            scene5.interactable = true;
        }

        if (PlayerPrefs.GetInt("sceneSixSold") == 1) {
            buyScene6.gameObject.SetActive(false);
            scene6.interactable = true;
        }
    }

    void Update () {}

    /* For each unlockable item, if a locked item is clicked on check if the user has enough coins */
    public void ShipTwoLockClicked() {

        if (PlayerPrefs.GetInt("Coins") >= 200 ) 
        {

            print("Player has enough credits");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
            PlayerPrefs.SetInt("shipTwoSold", 1);
            buyShip2.gameObject.SetActive(false);  // Disables buyButton and pricing
            ship2.interactable = true;  // Enables Toggle for ship
            purchased.Play(); // play buy sound
        }

        else {
            print("Player does not have enough credits");
            locked.Play(); // play sound            
        }
    }

    public void ShipThreeLockClicked()
    {

        if (PlayerPrefs.GetInt("Coins") >= 200)
        {

            print("Player has enough credits");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
            PlayerPrefs.SetInt("shipThreeSold", 1);
            buyShip3.gameObject.SetActive(false);  // Disables buyButton and pricing
            ship3.interactable = true;  // Enables Toggle for ship
            purchased.Play(); // play buy sound
        }

        else
        {
            print("Player does not have enough credits");
            locked.Play(); // play sound           
        }
    }


    public void ShipFourLockClicked()
    {

        if (PlayerPrefs.GetInt("Coins") >= 200)
        {

            print("Player has enough credits");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
            PlayerPrefs.SetInt("shipFourSold", 1);
            buyShip4.gameObject.SetActive(false);  // Disables buyButton and pricing
            ship4.interactable = true;  // Enables Toggle for ship
            purchased.Play(); // play buy sound
        }

        else
        {
            print("Player does not have enough credits");
            locked.Play(); // play sound           
        }
    }

    public void ShipFiveLockClicked()
    {

        if (PlayerPrefs.GetInt("Coins") >= 200)
        {

            print("Player has enough credits");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
            PlayerPrefs.SetInt("shipFiveSold", 1);
            buyShip5.gameObject.SetActive(false);  // Disables buyButton and pricing
            ship5.interactable = true;  // Enables Toggle for ship
            purchased.Play(); // play buy sound
        }

        else
        {
            print("Player does not have enough credits");
            locked.Play(); // play sound           
        }
    }

    public void SceneTwoLockClicked()
    {

        if (PlayerPrefs.GetInt("Coins") >= 200)
        {

            print("Player has enough credits");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
            PlayerPrefs.SetInt("sceneTwoSold", 1);
            buyScene2.gameObject.SetActive(false);  //Disables buyButton and pricing
            scene2.interactable = true;  // Enables Toggle for ship
            purchased.Play(); // play buy sound
        }

        else
        {
            print("Player does not have enough credits");
            locked.Play(); // play sound          
        }
    }

    public void SceneThreeLockClicked()
    {

        if (PlayerPrefs.GetInt("Coins") >= 200)
        {

            print("Player has enough credits");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
            PlayerPrefs.SetInt("sceneThreeSold", 1);
            buyScene3.gameObject.SetActive(false);  //Disables buyButton and pricing
            scene3.interactable = true;  // Enables Toggle for ship
            purchased.Play(); // play buy sound
        }

        else
        {
            print("Player does not have enough credits");
            locked.Play(); // play sound          
        }


    }

    public void SceneFourLockClicked()
    {

        if (PlayerPrefs.GetInt("Coins") >= 200)
        {

            print("Player has enough credits");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
            PlayerPrefs.SetInt("sceneFourSold", 1);
            buyScene4.gameObject.SetActive(false);  //Disables buyButton and pricing
            scene4.interactable = true;  // Enables Toggle for ship
            purchased.Play(); // play buy sound
        }

        else
        {
            print("Player does not have enough credits");
            locked.Play(); // play sound           
        }
    }

    public void SceneFiveLockClicked()
    {

        if (PlayerPrefs.GetInt("Coins") >= 200)
        {

            print("Player has enough credits");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
            PlayerPrefs.SetInt("sceneFiveSold", 1);
            buyScene5.gameObject.SetActive(false);  //Disables buyButton and pricing
            scene5.interactable = true;  // Enables Toggle for ship
            purchased.Play(); // play buy sound
        }

        else
        {
            print("Player does not have enough credits");
            locked.Play(); // play sound           
        }
    }

    public void SceneSixLockClicked()
    {

        if (PlayerPrefs.GetInt("Coins") >= 200)
        {

            print("Player has enough credits");
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
            PlayerPrefs.SetInt("sceneSixSold", 1);
            buyScene6.gameObject.SetActive(false);  //Disables buyButton and pricing
            scene6.interactable = true;  // Enables Toggle for ship
            purchased.Play(); // play buy sound
        }

        else
        {
            print("Player does not have enough credits");
            locked.Play(); // play sound         
        }
    }
}

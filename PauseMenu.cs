using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles the opening and closing of the pause menu during the game */
public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenu;

    GameManager gameManager;

	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}
    
    /* Sets time back to normal, closes menu */
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    /* Pauses game by setting time to 0, opens menu */
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Idea to implement return to menu in pause screen
    /* public void LoadMenu()
    {
        Time.timeScale = 1f;
        gameManager.ConfirmGameOver();
        //reset game, aka delete objects and reset paramets
        SceneManager.LoadScene("Menu")
        Debug.Log("Loading menu...");
    }
    */
}

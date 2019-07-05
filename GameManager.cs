using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Handles all of the UI events within the game,
 * - Switching pages 
 * - Starting/stopping the game
 * - Keeping track of scores
 */

public class GameManager : MonoBehaviour {

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public static GameManager Instance;

    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countdownPage;
    public GameObject optionsPage;
    public GameObject gamePage;
    public GameObject directionsPage;
    public GameObject shipsPage;
    public GameObject backDropPage;

	public AudioSource backgroundAudio;

    ScoreManager theScoreManager;

    LevelGenerator theLevel;
    CoinGenerator coinSpawn;

    PlayerMovement2 playmove;
    AlienMovement alienmove;
    
    public Text scoreText;
    public int coinsEarned;
    enum PageState{
        None,
        Game,
        Start,
        Ships,
        BackDrop,
        Options,
        Directions,
        GameOver,
        Countdown
    }

    int score = 0;
    int finalScore;
   
    bool gameOver = true;

    public bool GameOver {  get { return gameOver; } }
    public int Score { get { return score; } }

    void Awake() {
        Instance = this;
    }

    void OnEnable() {
        CountdownText.OnCountdownFinished += OnCountdownFinished;
        PlayerMovement2.OnPlayerDied += OnPlayerDied;
    }

    void OnDisable() {
        CountdownText.OnCountdownFinished -= OnCountdownFinished;
        PlayerMovement2.OnPlayerDied -= OnPlayerDied;
    }

    /* Starts the game by calling OnGameStarted */
    void OnCountdownFinished()
    {
        SetPageState(PageState.Game);
        OnGameStarted(); //event sent to Controller

        theScoreManager.scoreCount = 0;

        gameOver = false;
        theScoreManager.scoreIncreasing = true;
    }

    /* Stops the game, saves score, and adds coins collected to total */
    void OnPlayerDied(){
        gameOver = true;
        theScoreManager.scoreIncreasing = false;

        playmove.movement = false;
        alienmove.movement = false;

        Time.timeScale = 0f;

        int totalCoins = PlayerPrefs.GetInt("Coins");

        totalCoins = totalCoins + coinsEarned;

        PlayerPrefs.SetInt("Coins", totalCoins);

        coinsEarned = 0;

        int savedScore = PlayerPrefs.GetInt("HighScore");

        if (theScoreManager.scoreCount > savedScore) {
            finalScore = (int)Mathf.Round(theScoreManager.scoreCount);
            PlayerPrefs.SetInt("HighScore", finalScore);
        }
        SetPageState(PageState.GameOver);
    }

    void OnPlayerScored() {
        score++;
        scoreText.text = score.ToString();
    }

    /* Changes which page is presented */
    void SetPageState(PageState state) {
        switch (state) {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                optionsPage.SetActive(false);
                gamePage.SetActive(false);
                directionsPage.SetActive(false);
                backDropPage.SetActive(false);
                shipsPage.SetActive(false);
                break;

            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                optionsPage.SetActive(false);
                gamePage.SetActive(false);
                directionsPage.SetActive(false);
                backDropPage.SetActive(false);
                shipsPage.SetActive(false);
                break;

            case PageState.Directions:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                optionsPage.SetActive(false);
                gamePage.SetActive(false);
                directionsPage.SetActive(true);
                backDropPage.SetActive(false);
                shipsPage.SetActive(false);
                break;

            case PageState.Game:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                optionsPage.SetActive(false);
                gamePage.SetActive(true);
                directionsPage.SetActive(false);
                backDropPage.SetActive(false);
                shipsPage.SetActive(false);
                break;

            case PageState.Options:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                optionsPage.SetActive(true);
                gamePage.SetActive(false);
                directionsPage.SetActive(false);
                backDropPage.SetActive(false);
                shipsPage.SetActive(false);
                break;

            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countdownPage.SetActive(false);
                optionsPage.SetActive(false);
                gamePage.SetActive(false);
                directionsPage.SetActive(false);
                backDropPage.SetActive(false);
                shipsPage.SetActive(false);
                break;

            case PageState.BackDrop:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                optionsPage.SetActive(false);
                gamePage.SetActive(false);
                directionsPage.SetActive(false);
                backDropPage.SetActive(true);
                shipsPage.SetActive(false);
                break;

            case PageState.Ships:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                optionsPage.SetActive(false);
                gamePage.SetActive(false);
                directionsPage.SetActive(false);
                backDropPage.SetActive(false);
                shipsPage.SetActive(true);
                break;

            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(true);
                optionsPage.SetActive(false);
                gamePage.SetActive(true);
                directionsPage.SetActive(false);
                backDropPage.SetActive(false);
                shipsPage.SetActive(false);
                break;
        }
    }

    /* Calls OnGameOverConfirmed which resets the game objects
     * - resets the default values for difficulty 
     * - cleans up leftover game objects
     */
    public void ConfirmGameOver(){
        // activated when replay button is hit
        OnGameOverConfirmed(); //event sent to controller
        theScoreManager.scoreCount = 0;

        // Default values, but can be changed in unity
        theLevel.ySpawnTrigger = -2f;   // -2f
		theLevel.yDeSpawnTrigger = 23f; // 23f
        theLevel.yDifficultyTrigger = 60f; // 30f
        theLevel.numberOfRocks = 21;  // 20

        coinSpawn.ySpawnTrigger = -2f;
        coinSpawn.yDeSpawnTrigger = 23f;
        //coinSpawn.yDifficultyTrigger = 60f;
        //coinSpawn.numberOfCoins = 2;

        Time.timeScale = 1f;

        SetPageState(PageState.Start);
        theLevel.DestroyAllGameObjects();
        coinSpawn.DestroyAllGameObjects();
    }

    /* Initiates the Countdown for the game and finds all objects needed for the game */
    public void StartGame(){
        // activated when play button is hit
        SetPageState(PageState.Countdown);
        theScoreManager = FindObjectOfType<ScoreManager>();
        theLevel = FindObjectOfType<LevelGenerator>();
        coinSpawn = FindObjectOfType<CoinGenerator>();
        playmove = FindObjectOfType<PlayerMovement2>();
        alienmove = FindObjectOfType<AlienMovement>();
    }

    /* Closes the application.  Taken out of the game for iOS */
    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    /* Each of these just change the page state when a buttion is pressed */
    public void MenuPlayClicked() {
        SetPageState(PageState.Directions);
    }

    public void ShipsClicked() {
        SetPageState(PageState.Ships);
    }

    public void BackDropClicked() {
        SetPageState(PageState.BackDrop);
    }

    public void OptionsClicked() {
        SetPageState(PageState.Options);
    }

    public void BackClicked() {
        SetPageState(PageState.Start);
    }

    public void GameOverMenuBack() {
        SetPageState(PageState.GameOver);
    }
}


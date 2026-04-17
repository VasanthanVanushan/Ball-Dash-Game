using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    Pause,
    extraLife,
    GameOver
}


public class StateManagerScript : MonoBehaviour
{
    public static StateManagerScript instance;

    public GameObject InGameMenuUi;
    public GameObject PauseMenuUi;
    public GameObject ExtraLifeMenuUi;
    public GameObject GameOverMenuUi;

    public GameState CurrentState { get; private set;}

    public float delay = 1f;
    public int extraLifeCoinAmount = 50;

    private bool isGameOverHandled = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    private void Start()
    {
        ChangeState(GameState.Playing);
    }



    public void ChangeState(GameState newState)
    {
        StartCoroutine(TransitionToState(newState));
    }


        //Click Events
        public void ChangeToMainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        public void ChangeToPlaying()
        {
            ChangeState(GameState.Playing);
        }
        public void ChangeToPause()
        {
            ChangeState(GameState.Pause);
        }
        public void ChangeToExtraLife()
        {
            ChangeState(GameState.extraLife);
        }
        public void ChangeToExtraLifeAccepted()
        {   
            int totalCoinsCollected = PlayerPrefs.GetInt("TotalCoins", 0);
            if(totalCoinsCollected >= extraLifeCoinAmount)
            {
                totalCoinsCollected = totalCoinsCollected - extraLifeCoinAmount;
                PlayerPrefs.SetInt("TotalCoins", totalCoinsCollected);
                PlayerPrefs.Save();
                ChangeState(GameState.Playing);
            }
            else
            {
                Debug.Log("Not enough coins for extra life");
                //Soon
            }
        }
        public void ChangeToGameOver()
        {
            ChangeState(GameState.GameOver);
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }



    private IEnumerator TransitionToState(GameState newState)
    {
        if(newState != GameState.Playing)
        {
            yield return new WaitForSecondsRealtime(delay);
        }
        CurrentState = newState;
        HandleStateChange();
    }

    private void HandleStateChange()
    {
        HideAllMenu();
        switch(CurrentState)
        {
            case GameState.Playing:
                Time.timeScale = 1;
                InGameMenuUi.SetActive(true);
                AudioManagerScript.instance.PlayMusic(AudioManagerScript.instance.inGameClip);
                break;
            case GameState.Pause:
                Time.timeScale = 0;
                PauseMenuUi.SetActive(true);
                AudioManagerScript.instance.PlayMusic(AudioManagerScript.instance.menuClip);
                break;
            case GameState.extraLife:
                Time.timeScale = 0;
                ExtraLifeMenuUi.SetActive(true);
                AudioManagerScript.instance.PlayMusic(AudioManagerScript.instance.menuClip);

                int Score = ScoreManagerScript.instance.GetScore();
                int CoinScore = CoinManagerScript.instance.GetCoinScore();

                ScoreManagerScript.instance.extraLifeScore(Score);
                CoinManagerScript.instance.extraLifeCoinScore(CoinScore);

                CoinManagerScript.instance.totalCoinsDisplay();
                break;
            case GameState.GameOver: 
                Time.timeScale = 0;
                GameOverMenuUi.SetActive(true);
                AudioManagerScript.instance.PlayMusic(AudioManagerScript.instance.menuClip);

                int currentScore = ScoreManagerScript.instance.GetScore();
                int currentCoinScore = CoinManagerScript.instance.GetCoinScore();
                
                ScoreManagerScript.instance.gameOverScore(currentScore);
                CoinManagerScript.instance.gameOverCoinScore(currentCoinScore);

                HighScoreManagerScript.instance.CheckAndSaveHighScore(currentScore);  //For HighScore Checking


                if(isGameOverHandled == false)
                {
                    CoinManagerScript.instance.totalCoinsCollected(currentCoinScore);   //Home Menu->Total Coins
                    isGameOverHandled = true;
                }
                break;
        }
    }


    private void HideAllMenu()
    {
        InGameMenuUi.SetActive(false);
        PauseMenuUi.SetActive(false);
        GameOverMenuUi.SetActive(false);
        ExtraLifeMenuUi.SetActive(false);
    }

}

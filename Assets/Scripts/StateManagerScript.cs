using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    Playing,
    Pause,
    GameOver
}


public class StateManagerScript : MonoBehaviour
{
    public static StateManagerScript instance;


    public GameObject MainMenuUi;
    public GameObject InGameMenuUi;
    public GameObject PauseMenuUi;
    public GameObject GameOverMenuUi;



    public GameState CurrentState { get; private set;}

    public float delay = 1f;

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
        ChangeState(GameState.MainMenu);
    }



    public void ChangeState(GameState newState)
    {
        StartCoroutine(TransitionToState(newState));
    }


        //Click Events
        public void ChangeToMainMenu()
        {
            ChangeState(GameState.MainMenu);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void ChangeToPlaying()
        {
            ChangeState(GameState.Playing);
        }
        public void ChangeToPause()
        {
            ChangeState(GameState.Pause);
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
        if(newState != GameState.MainMenu)
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
            case GameState.MainMenu:
                Time.timeScale = 0;
                MainMenuUi.SetActive(true);
                AudioManagerScript.instance.PlayMusic(AudioManagerScript.instance.menuClip);
                break;
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
            case GameState.GameOver: 
                Time.timeScale = 0;
                GameOverMenuUi.SetActive(true);
                AudioManagerScript.instance.PlayMusic(AudioManagerScript.instance.menuClip);
                break;
        }
    }


    private void HideAllMenu()
    {
        MainMenuUi.SetActive(false);
        InGameMenuUi.SetActive(false);
        PauseMenuUi.SetActive(false);
        GameOverMenuUi.SetActive(false);
    }

}

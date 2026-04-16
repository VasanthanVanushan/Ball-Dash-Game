using UnityEngine;
using TMPro;

public class HighScoreManagerScript : MonoBehaviour
{
    public static HighScoreManagerScript instance;

    private int highScore;

    public TextMeshProUGUI HighScoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        // Load saved high scores
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        UpdateUI();
    }


    // Call this when game ends
    public void CheckAndSaveHighScore(int score)
    {

        if (score > highScore)
        {
            highScore = score;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        HighScoreText.text = highScore.ToString();
    }
}
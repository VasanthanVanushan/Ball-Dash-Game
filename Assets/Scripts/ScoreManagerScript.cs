using UnityEngine;
using TMPro;

public class ScoreManagerScript : MonoBehaviour
{
    public static ScoreManagerScript instance;       //Singleton for global access
    private int Score = 0 ;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI gameOverScoreText;


    public int multiplayer =1;

    private Transform player;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void Update()
    {
        updateScore();
    }


    private void updateScore()
    {
        Score = Mathf.FloorToInt(player.position.z * multiplayer);
        ScoreText.text = Score.ToString();
    }

    public void gameOverScore()
    {
        gameOverScoreText.text = Score.ToString();
    }

}

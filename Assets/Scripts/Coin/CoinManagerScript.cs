using UnityEngine;
using TMPro;

public class CoinManagerScript : MonoBehaviour
{
    public static CoinManagerScript instance;       //Singleton for global access
    private int totalCoins = 0 ;

    public TextMeshProUGUI coinScoreText;
    public TextMeshProUGUI gameOverCoinScoreText;


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
    }


    public void addCoin(int amount)
    {
        totalCoins = totalCoins + amount ;
        //Debug.Log("Total Coins : " + totalCoins);

        coinScoreText.text = totalCoins.ToString();
    }

    public void gameOverCoinScore()
    {
        gameOverCoinScoreText.text = totalCoins.ToString();
    }

}

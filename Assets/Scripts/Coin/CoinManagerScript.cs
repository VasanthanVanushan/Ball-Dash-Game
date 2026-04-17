using UnityEngine;
using TMPro;

public class CoinManagerScript : MonoBehaviour
{
    public static CoinManagerScript instance;       //Singleton for global access
    private int currentCoins = 0 ;

    public TextMeshProUGUI coinScoreText;
    public TextMeshProUGUI gameOverCoinScoreText;
    public TextMeshProUGUI extraLifeCoinScoreText;

    public TextMeshProUGUI extraLifeTotalCoinsText;


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
        currentCoins = currentCoins + amount ;
        //Debug.Log("Total Coins : " + totalCoins);

        coinScoreText.text = currentCoins.ToString();
    }

    public void extraLifeCoinScore(int coinScore)
    {
        extraLifeCoinScoreText.text = coinScore.ToString();
    }

    public void gameOverCoinScore(int coins)
    {
        gameOverCoinScoreText.text = coins.ToString();
    }

    public int GetCoinScore()  
    {
        return currentCoins;
    }



    public void totalCoinsCollected(int collectedCoins)   //Total Coins usage
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoins += collectedCoins;

        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
    }


    public void totalCoinsDisplay()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        extraLifeTotalCoinsText.text = totalCoins.ToString();
    }

}

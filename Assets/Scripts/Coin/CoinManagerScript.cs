using UnityEngine;
using TMPro;

public class CoinManagerScript : MonoBehaviour
{
    public static CoinManagerScript instance;       //Singleton for global access
    private int currentCoins = 0 ;

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
        currentCoins = currentCoins + amount ;
        //Debug.Log("Total Coins : " + totalCoins);

        coinScoreText.text = currentCoins.ToString();
    }

    public void gameOverCoinScore(int coins)
    {
        gameOverCoinScoreText.text = coins.ToString();
    }

    public int GetCoinScore()  
    {
        return currentCoins;
    }



    public void totalCoinsCollected(int collectedCoins)   //Home Menu usage
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoins += collectedCoins;

        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
    }

}

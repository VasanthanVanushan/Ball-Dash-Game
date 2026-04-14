using UnityEngine;

public class CoinManagerScript : MonoBehaviour
{
    public static CoinManagerScript instance;       //Singleton for global access
    private int totalCoins = 0 ;


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
        Debug.Log("Total Coins : " + totalCoins);
    }

}

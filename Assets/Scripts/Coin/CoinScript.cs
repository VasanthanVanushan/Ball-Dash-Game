using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int coinValue=1;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            AudioManagerScript.instance.PlaySFX(AudioManagerScript.instance.coinClip);
            CoinManagerScript.instance.addCoin(coinValue);  //Increase the coin
            Destroy(gameObject);
        }
    }
}

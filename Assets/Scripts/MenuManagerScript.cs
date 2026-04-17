using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManagerScript : MonoBehaviour
{
    public TextMeshProUGUI totalCoinsText;

    void Start()
    {
        AudioManagerScript.instance.PlayMusic(AudioManagerScript.instance.menuClip);

        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoinsText.text = totalCoins.ToString();
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

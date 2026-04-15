using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource musicSource; //Speaker1
    public AudioSource sfxSource;   //Speaker2


    [Header("Audio Clips")]
    public AudioClip coinClip;
    public AudioClip inGameClip;
    public AudioClip collisionClip;
    public AudioClip menuClip;

    
    public static AudioManagerScript instance;      //Singleton -> Manager scripts are meant to be: Global (accessible from anywhere) , Unique (only one should exist)

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  //Unity keeps this object alive across all scenes... Music keeps playing smoothly, No restart between scenes
                                            //Without DontDestroyOnLoad What happens: Scene changes -> AudioManager gets destroyed -> Music stops suddenly -> New AudioManager is created (if exists in next scene) -> Sound cuts off & Music restarts
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void Start()
    {
        PlayMusic(inGameClip);
    }

    
    public void PlayMusic(AudioClip musicClip)
    {
        if(musicSource != null && musicClip != null)
        {
            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.volume = 0.2f;
            musicSource.Play();                 //Play() -> Uses the assigned clip
        }
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        if(sfxSource != null && sfxClip != null)
        {
            sfxSource.volume = 0.2f;
            sfxSource.PlayOneShot(sfxClip);     //PlayOneShot() -> Does NOT use .clip & Can play multiple sounds at once
        }
    }


    public void StopMusic()
    {
        if(musicSource != null)
        {
            musicSource.Stop();
        }                           
        //No need to stop SFX sound bcz those are one time playable. So that no SFX source code here.
    }
}
